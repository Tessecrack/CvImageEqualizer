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
            var srcMat = new Mat(pathToImage, Emgu.CV.CvEnum.ImreadModes.Grayscale);

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

            var contouredMat = GetContouredMat(binaryMat);

            result.EqualizedImage = grayMat;
            result.FilteredImage = filteredMat;
            result.BinaryImage = binaryMat;
            result.ExtractedROI = contouredMat;
            result.AngleDeviationDegrees = 0;
            return result;
        }

        private Mat GetContouredMat(Mat srcMat)
        {
            Mat contouredMat = new Mat();
            srcMat.CopyTo(contouredMat);

            Mat hierarchy = new Mat();
            CvInvoke.CvtColor(contouredMat, contouredMat, ColorConversion.Gray2Bgr);
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
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
                    if (center.X > rect.Left && center.X < rect.Right
                        && center.Y > rect.Top && center.Y < rect.Bottom)
                    {
                        if (width * height > 3000)
                            CvInvoke.Rectangle(contouredMat, rect, new MCvScalar(255, 0, 0));
                    }

                }
            }

            return contouredMat;
        }
    }
}
