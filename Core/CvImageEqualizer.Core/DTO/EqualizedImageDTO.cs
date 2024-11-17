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
        /// Бинарное изображение.
        /// </summary>
        public Mat BinaryImage { get; set; }

        /// <summary>
        /// Выделенная область интереса (прямоугольник). Нужен только для отображения.
        /// </summary>
        public Mat ExtractedROI { get; set; }

        /// <summary>
        /// Угол отклонения исходного изображения.
        /// </summary>
        public float AngleDeviationDegrees { get; set; }
    }
}
