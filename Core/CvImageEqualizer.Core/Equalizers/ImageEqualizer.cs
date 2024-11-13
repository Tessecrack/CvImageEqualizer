using CvImageEqualizer.Core.DTO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.Drawing;
namespace CvImageEqualizer.Core.Equalizers
{
    public class ImageEqualizer
    {
        public EqualizedImageDTO Equalize(string pathToImage)
        {
            var srcMat = new Mat(pathToImage, ImreadModes.Grayscale);

            var result = EqualizeImpl(srcMat);

            return result;
        }

        private EqualizedImageDTO EqualizeImpl(Mat grayMat)
        {
            var result = new EqualizedImageDTO();

            Mat filteredMat = new Mat();
            CvInvoke.BilateralFilter(grayMat, filteredMat, 9, 71, 71,
                BorderType.Constant);

            //Mat cannyMat = new Mat();
            //CvInvoke.Canny(filteredMat, cannyMat, 10, 60);

            var binaryMat = new Mat();
            CvInvoke.AdaptiveThreshold(filteredMat, binaryMat, 255,
                AdaptiveThresholdType.GaussianC,
                ThresholdType.Binary, 19, 2);

            var contouredMat = GetContouredMat(binaryMat, out float angle);
            var extractedRoi = new Mat();
            CvInvoke.BitwiseAnd(filteredMat, contouredMat, extractedRoi);

            result.EqualizedImage = grayMat;
            result.FilteredImage = filteredMat;
            result.BinaryImage = binaryMat;
            result.ExtractedROI = extractedRoi;
            result.AngleDeviationDegrees = angle;
            return result;
        }

        private Mat GetContouredMat(Mat srcMat, out float angle)
        {
            Mat maskRoi = Mat.Zeros(srcMat.Rows, srcMat.Cols, DepthType.Cv8U, 1);
            angle = 0;
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                Mat hierarchy = new Mat();
                CvInvoke.FindContours(srcMat, contours, hierarchy,
                    RetrType.Ccomp,
                    ChainApproxMethod.ChainApproxSimple);
                Point center = new Point(srcMat.Cols / 2, srcMat.Rows / 2);
                for (int i = 0; i < contours.Size; ++i)
                {
                    var contour = contours[i];
                    Rectangle rect = CvInvoke.BoundingRectangle(contour);
                    var width = rect.Right - rect.Left;
                    var height = rect.Bottom - rect.Top;
                    if (rect.Left == 0 || rect.Right == srcMat.Width
                        || rect.Top == 0 || rect.Bottom == srcMat.Height)
                    {
                        continue;
                    }
                    if (center.X > rect.Left && center.X < rect.Right
                        && center.Y > rect.Top && center.Y < rect.Bottom)
                    {
                        if (width * height > 3000)
                        {
                            //CvInvoke.Rectangle(maskRoi, rect, new MCvScalar(255), -1);
                            var minAreaRect = CvInvoke.MinAreaRect(contour);
                            angle = minAreaRect.Angle;
                            CvInvoke.Rectangle(maskRoi, minAreaRect.MinAreaRect(), 
                                new MCvScalar(255), -1);
                            break;
                        }
                    }
                }
            }
            return maskRoi;
        }
    }
}
