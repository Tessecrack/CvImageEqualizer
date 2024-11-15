using CvImageEqualizer.Core.DTO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing;
namespace CvImageEqualizer.Core.Equalizers
{
    public class ImageEqualizer
    {
        private Mat _cachedMat;

        private int _sizeRoi = 2000;

        public EqualizedImageDTO Equalize(string pathToImage)
        {
            _cachedMat = new Mat(pathToImage, ImreadModes.Color);
            var srcMat = new Mat(pathToImage, ImreadModes.Grayscale);

            var result = EqualizeImpl(srcMat);

            return result;
        }

        private EqualizedImageDTO EqualizeImpl(Mat grayMat)
        {
            var result = new EqualizedImageDTO();

            Mat filteredMat = new Mat();
            CvInvoke.BilateralFilter(grayMat, filteredMat, 9, 23, 23,
                BorderType.Constant);

            var binaryMat = new Mat();
            CvInvoke.AdaptiveThreshold(filteredMat, binaryMat, 255,
                AdaptiveThresholdType.GaussianC,
                ThresholdType.Binary, 19, 2);
            var erodeCore = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(binaryMat, binaryMat, erodeCore, new Point(-1, -1), 1, BorderType.Constant
                , new MCvScalar(255));
            var rotatedMat = RotateMat(binaryMat, _cachedMat, 
                out Mat roi, 
                out float angle);
            var extractedRoi = new Mat();
            CvInvoke.BitwiseAnd(grayMat, roi, extractedRoi);

            result.EqualizedImage = rotatedMat;
            result.FilteredImage = filteredMat;
            result.BinaryImage = binaryMat;
            result.ExtractedROI = extractedRoi;
            result.AngleDeviationDegrees = angle;
            return result;
        }

        private Mat RotateMat(Mat binaryMat, Mat srcMat, out Mat maskRoi, out float angle)
        {
            maskRoi = Mat.Zeros(binaryMat.Rows, binaryMat.Cols, DepthType.Cv8U, 1);
            var rotatedResult = new Mat();
            var minAreaRect = new RotatedRect();
            angle = 0;
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                Mat hierarchy = new Mat();
                CvInvoke.FindContours(binaryMat, contours, hierarchy,
                    RetrType.Ccomp,
                    ChainApproxMethod.ChainApproxSimple);
                Point center = new Point(binaryMat.Cols / 2, binaryMat.Rows / 2);
                for (int i = 0; i < contours.Size; ++i)
                {
                    var contour = contours[i];
                    Rectangle rect = CvInvoke.BoundingRectangle(contour);
                    var width = rect.Right - rect.Left;
                    var height = rect.Bottom - rect.Top;
                    if (rect.Left == 0 || rect.Right == binaryMat.Width
                        || rect.Top == 0 || rect.Bottom == binaryMat.Height)
                    {
                        continue;
                    }
                    if (center.X > rect.Left && center.X < rect.Right
                        && center.Y > rect.Top && center.Y < rect.Bottom)
                    {
                        if (width * height > _sizeRoi)
                        {
                            minAreaRect = CvInvoke.MinAreaRect(contour);
                            break;
                        }
                    }
                }
            }
            angle = GetOptimalAngle(minAreaRect.Angle);
            CvInvoke.Rectangle(maskRoi, minAreaRect.MinAreaRect(), new MCvScalar(255), -1);
            rotatedResult = ApplyRotation(_cachedMat, minAreaRect, angle);
            return rotatedResult;
        }

        private Mat ApplyRotation(Mat srcMat, RotatedRect minAreaRect, float angle)
        {
            var rotatedResult = new Mat();
            var rotationMatrix = new Mat(new Size(2, 3), DepthType.Cv32F, 1);
            CvInvoke.GetRotationMatrix2D(minAreaRect.Center, angle, 1.0, rotationMatrix);
            CvInvoke.WarpAffine(srcMat, rotatedResult, rotationMatrix, srcMat.Size,
                Inter.Cubic, Warp.Default, BorderType.Replicate);

            return rotatedResult;
        }

        private float GetOptimalAngle(float srcAngle)
        {
            int roundAngle = (int)srcAngle;
            var resultAngle = srcAngle;
            if (roundAngle == 90 || roundAngle == 180 || roundAngle == 270)
            {
                return 0;
            }
            float rightAngle = 90;
            float range = 10;
            if (rightAngle + range >= roundAngle && rightAngle - range <= roundAngle)
            {
                resultAngle = srcAngle - rightAngle;
            }

            return resultAngle;
        }
    }
}
