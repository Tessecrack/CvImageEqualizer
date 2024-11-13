using CvImageEqualizer.Core.DTO;
using Emgu.CV;

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
            CvInvoke.BilateralFilter(grayMat, filteredMat, 9, 103, 103, Emgu.CV.CvEnum.BorderType.Constant);

            //Mat cannyMat = new Mat();
            //CvInvoke.Canny(filteredMat, cannyMat, 10, 60);

            var bin = new Mat();
            CvInvoke.AdaptiveThreshold(filteredMat, bin, 255,
                Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
                Emgu.CV.CvEnum.ThresholdType.BinaryInv, 11, 2);

            CvInvoke.Imshow("bin", bin);

            result.EqualizedImage = grayMat;
            result.FilteredImage = filteredMat;
            result.AngleDeviationDegrees = 0;
            return result;
        }
    }
}
