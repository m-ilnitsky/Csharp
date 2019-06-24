using System;
using System.Drawing;

namespace Task06_Blur
{
    internal class Blur
    {
        private static byte GetByte(double color)
        {
            if (color < 0)
            {
                return 0;
            }

            if (color > 255)
            {
                return 255;
            }

            return (byte)color;
        }

        private static Bitmap Convolution(Bitmap inputImage, double[,] matrix)
        {
            var resultImage = new Bitmap(inputImage);

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("ОШИБКА: Матрица не квадратная! Изображение не будет преобразовано!");
                return resultImage;
            }

            if (matrix.GetLength(0) % 2 == 0)
            {
                Console.WriteLine("ОШИБКА: Матрица чётного размера! Изображение не будет преобразовано!");
                return resultImage;
            }

            var matrixSize = matrix.GetLength(0);
            var matrixShift = matrixSize / 2;

            var height = inputImage.Height - matrixShift;
            var width = inputImage.Width - matrixShift;

            for (var y = matrixShift; y < height; ++y)
            {
                for (var x = matrixShift; x < width; ++x)
                {
                    double r = 0;
                    double g = 0;
                    double b = 0;

                    for (var i = 0; i < matrixSize; ++i)
                    {
                        for (var j = 0; j < matrixSize; ++j)
                        {
                            var matrixPixel = inputImage.GetPixel(x - matrixShift + j, y - matrixShift + i);
                            r += matrixPixel.R * matrix[j, i];
                            g += matrixPixel.G * matrix[j, i];
                            b += matrixPixel.B * matrix[j, i];
                        }
                    }

                    resultImage.SetPixel(x, y, Color.FromArgb(GetByte(r), GetByte(g), GetByte(b)));
                }
            }

            return resultImage;
        }

        public static Bitmap InvertColor(Bitmap inputImage)
        {
            var resultImage = new Bitmap(inputImage);
            const int maxRgb = 255;

            for (var y = 0; y < resultImage.Height; ++y)
            {
                for (var x = 0; x < resultImage.Width; ++x)
                {
                    var pixel = resultImage.GetPixel(x, y);
                    var newColor = Color.FromArgb(maxRgb - pixel.R, maxRgb - pixel.G, maxRgb - pixel.B);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        public static Bitmap ConvertToBlackAndWhite(Bitmap inputImage)
        {
            var resultImage = new Bitmap(inputImage);
            const double coefficientR = 0.3;
            const double coefficientG = 0.59;
            const double coefficientB = 0.11;

            for (var y = 0; y < resultImage.Height; ++y)
            {
                for (var x = 0; x < resultImage.Width; ++x)
                {
                    var pixel = resultImage.GetPixel(x, y);
                    var rgb = GetByte(pixel.R * coefficientR + pixel.G * coefficientG + pixel.B * coefficientB);
                    var newColor = Color.FromArgb(rgb, rgb, rgb);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        private static void Main()
        {
            var image = new Bitmap("..\\..\\image.jpg");

            var blackAndWhiteImage = ConvertToBlackAndWhite(image);
            blackAndWhiteImage.Save("outBlackAndWhite.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("blackAndWhiteImage Ok!");

            var invertedColorImage = InvertColor(image);
            invertedColorImage.Save("outInvertedColor.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("invertedColorImage Ok!");

            double[,] blurMatrix =
            {
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 },
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 },
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 }
            };

            var blurImage = Convolution(image, blurMatrix);
            blurImage.Save("outBlur.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("blurImage Ok!");

            double[,] sharpnessMatrix =
            {
                {  0, -1,  0 },
                { -1,  5, -1 },
                {  0, -1,  0 }
            };

            var sharpedImage = Convolution(image, sharpnessMatrix);
            sharpedImage.Save("outSharped.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("sharpedImage Ok!");

            double[,] stampingMatrix =
            {
                {  0,  1, 0 },
                { -1,  0, 1 },
                {  0, -1, 0 }
            };

            var stampedImage = Convolution(blackAndWhiteImage, stampingMatrix);
            stampedImage.Save("outStamped.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("stampedImage Ok!");

            Console.ReadLine();
        }
    }
}
