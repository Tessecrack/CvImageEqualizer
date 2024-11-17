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
        /// <summary>
        /// Кэшированное исходное изображение для применения ротации.
        /// </summary>
        private Mat _cachedMat;

        /// <summary>
        /// Минимальная площадь области интереса для выделения контура.
        /// </summary>
        private readonly int _minAreaRoi = 2000;

        /// <summary>
        /// Размер ядра эрозии
        /// </summary>
        private readonly int _sizeErosionCore = 2;

        /// <summary>
        /// Метод выравнивания ихсодного изображения.
        /// </summary>
        /// <param name="pathToImage">Путь к исходному изображению.</param>
        /// <returns>Объект, содержащий выровненное, фильтрованное, бинарное изображения, область интереса и угол отклонения.</returns>
        public EqualizedImageDTO Equalize(string pathToImage)
        {
            _cachedMat = new Mat(pathToImage, ImreadModes.Color);
            var srcMat = new Mat();

            CvInvoke.CvtColor(_cachedMat, srcMat, ColorConversion.Bgr2Gray);

            return EqualizeImpl(srcMat);
        }

        /// <summary>
        /// Метод выравнивания исходного изображения.
        /// </summary>
        /// <param name="grayMat">Изображение в оттенках серого.</param>
        /// <returns>Объект, содержащий выровненное, фильтрованное, бинарное изображения, область интереса и угол отклонения.</returns>
        private EqualizedImageDTO EqualizeImpl(Mat grayMat)
        {
            var result = new EqualizedImageDTO();

            Mat filteredMat = new Mat();
            CvInvoke.BilateralFilter(grayMat, filteredMat, 9, 23, 23,
                BorderType.Constant);

            var binaryMat = GetBinaryWithErosion(filteredMat, _sizeErosionCore);

            // получение прямоугольника (по контуру), по которому будет определен угол поворота
            var minAreaRect = ExtracMinAreaRect(binaryMat);

            // проецируем угол на первую четверть
            var angleInFirstQuarter = ConvertAngleToFirstQuarter(minAreaRect.Angle);

            // поворот исходного изображения относительно цента области интереса minAreaRect
            var rotatedMat = ApplyRotationByRect(_cachedMat, minAreaRect, angleInFirstQuarter, out Mat roi);

            var extractedRoi = new Mat();

            CvInvoke.BitwiseAnd(grayMat, roi, extractedRoi);

            result.EqualizedImage = rotatedMat;
            result.FilteredImage = filteredMat;
            result.BinaryImage = binaryMat;
            result.ExtractedROI = extractedRoi;
            result.AngleDeviationDegrees = angleInFirstQuarter;
            return result;
        }

        /// <summary>
        /// Метод используется для применения адаптивной бинаризации и эрозии к srcMat.
        /// </summary>
        /// <param name="srcMat">Исходное изображение.</param>
        /// <param name="sizeErode">Размер ядра эрозии</param>
        /// <returns>Бинарное изображение с эрозией.</returns>
        private Mat GetBinaryWithErosion(Mat srcMat, int sizeErode)
        {
            var binaryMat = new Mat();
            CvInvoke.AdaptiveThreshold(srcMat, binaryMat, 255,
                AdaptiveThresholdType.GaussianC,
                ThresholdType.Binary, 19, 2);

            var erosionCore = CvInvoke.GetStructuringElement(ElementShape.Rectangle, 
                new Size(sizeErode, sizeErode), 
                new Point(-1, -1));

            CvInvoke.Erode(binaryMat, binaryMat, erosionCore, new Point(-1, -1), 1, BorderType.Constant
                , new MCvScalar(255));

            return binaryMat;
        }

        /// <summary>
        /// Извлечение повернутого прямоугольника над областью интереса.
        /// </summary>
        /// <param name="binaryMat">Бинарное изображение.</param>
        /// <returns>Область интереса в binaryMat в прямоугольнике.</returns>
        private RotatedRect ExtracMinAreaRect(Mat binaryMat)
        {
            var minAreaRect = new RotatedRect();
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

                    // обход границ изображения
                    if (rect.Left == 0 || rect.Right == binaryMat.Width
                        || rect.Top == 0 || rect.Bottom == binaryMat.Height)
                    {
                        continue;
                    }

                    // контур считается областью интереса, если включает в себя центр исходного изображения
                    if (center.X > rect.Left && center.X < rect.Right
                        && center.Y > rect.Top && center.Y < rect.Bottom)
                    {
                        // определение области интереса по размеру (площади прямоугольника) для отсечения
                        // совсем мелких контуров
                        if (width * height > _minAreaRoi)
                        {
                            minAreaRect = CvInvoke.MinAreaRect(contour);
                            break;
                        }
                    }
                }
            }
            return minAreaRect;
        }

        /// <summary>
        /// Применение ротации к srcMat по контуру minAreaRect на угол angleInFirstQuarter.
        /// </summary>
        /// <param name="srcMat">Исходное изображение.</param>
        /// <param name="minAreaRect">Повернутый прямоугольник, содержащий область интереса.</param>
        /// <param name="maskRoi">(Выходной) Область интереса, наложенная на черный фон.</param>
        /// <param name="optimalAngle">(Выходной) Угол спроецированный на первую четверть.</param>
        /// <returns>Повернутое изображение.</returns>
        private Mat ApplyRotationByRect(Mat srcMat, RotatedRect minAreaRect, float angleInFirstQuarter,
            out Mat maskRoi)
        {
            maskRoi = Mat.Zeros(srcMat.Rows, srcMat.Cols, DepthType.Cv8U, 1);

            CvInvoke.Rectangle(maskRoi, minAreaRect.MinAreaRect(), new MCvScalar(255), -1);

            var rotatedResult = new Mat();
            var rotationMatrix = new Mat(new Size(2, 3), DepthType.Cv32F, 1);

            CvInvoke.GetRotationMatrix2D(minAreaRect.Center, angleInFirstQuarter, 1.0, rotationMatrix);
            CvInvoke.WarpAffine(srcMat, rotatedResult, rotationMatrix, srcMat.Size,
                Inter.Cubic, Warp.Default, BorderType.Replicate);

            return rotatedResult;
        }

        /// <summary>
        /// Метод проецирования угла на первую четверть.
        /// </summary>
        /// <param name="srcAngle">Исходный угол.</param>
        /// <returns>Угол, спроецированный на первую четверть.</returns>
        private float ConvertAngleToFirstQuarter(float srcAngle)
        {
            // текущая четверть угла
            int currentQuarter = (int)srcAngle / 90;
            float convertedAngleToFirstQuarter = srcAngle - currentQuarter * 90;
            // проверка на переворот изображения относительно 90, 180, 270 градусов
            // ("флип" изображения не нужен)
            if (Math.Abs((int)convertedAngleToFirstQuarter) == 90)
            {
                return 0;
            }

            // маппинг угла на ближайшую ось 45 градусов
            int approxValueToNearestAxis = (int)Math.Round(convertedAngleToFirstQuarter / 45f);
            float resultAngle = srcAngle - approxValueToNearestAxis * 45;

            // обходим флипы
            if (Math.Abs((int)resultAngle) == 90)
            {
                return 0;
            }

            return resultAngle;
        }
    }
}
