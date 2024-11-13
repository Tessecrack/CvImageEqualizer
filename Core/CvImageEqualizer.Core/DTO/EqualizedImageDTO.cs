using Emgu.CV;

namespace CvImageEqualizer.Core.DTO
{
    public class EqualizedImageDTO
    {
        /// <summary>
        /// Выровненное изображение.
        /// </summary>
        public Mat EqualizedImage { get; set; }


        /// <summary>
        /// Фильтрованное изображение.
        /// </summary>
        public Mat FilteredImage { get; set; }

        /// <summary>
        /// Угол отклонения исходного изображения.
        /// </summary>
        public int AngleDeviationDegrees { get; set; }
    }
}
