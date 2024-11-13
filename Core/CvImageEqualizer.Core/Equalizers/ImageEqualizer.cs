using CvImageEqualizer.Core.DTO;
using Emgu.CV;
using Emgu.CV.CvEnum;
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
                ThresholdType.BinaryInv, 19, 2);


            result.EqualizedImage = grayMat;
            result.FilteredImage = filteredMat;
            result.BinaryImage = binaryMat;
            result.AngleDeviationDegrees = 0;
            return result;
        }
    }
}
