using System;
using System.Drawing;

namespace Task06_Blur
{
    class Blur
    {
        private static byte getByte(double color)
        {
            if (color < 0)
            {
                return 0;
            }
            else if (color > 255)
            {
                return 255;
            }              
           
            return (byte)color;
        }

        private static Bitmap Convolution(Bitmap inputImage, double[,] matrix)
        {
            Bitmap resultImage = new Bitmap(inputImage);

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("ОШИБКА: Матрица не квадратная! Изображение не будет преобразовано!");
                return resultImage;
            }
            else if (matrix.GetLength(0) % 2 == 0)
            {
                Console.WriteLine("ОШИБКА: Матрица чётного размера! Изображение не будет преобразовано!");
                return resultImage;
            }

            int matrixSize = matrix.GetLength(0);
            int matrixShift = matrixSize / 2;

            int height = inputImage.Height - matrixShift;
            int width = inputImage.Width - matrixShift;

            for (int y = matrixShift; y < height; ++y)
            {
                for (int x = matrixShift; x < width; ++x)
                {
                    double r = 0;
                    double g = 0;
                    double b = 0;

                    for (int i = 0; i < matrixSize; ++i)
                    {
                        for (int j = 0; j < matrixSize; ++j)
                        {
                            Color matrixPixel = inputImage.GetPixel(x - matrixShift + j, y - matrixShift + i);
                            r += matrixPixel.R * matrix[j, i];
                            g += matrixPixel.G * matrix[j, i];
                            b += matrixPixel.B * matrix[j, i];
                        }
                    }

                    resultImage.SetPixel(x, y, Color.FromArgb(getByte(r), getByte(g), getByte(b)));
                }
            }

            return resultImage;
        }

        public static Bitmap InvertColor(Bitmap inputImage)
        {
            Bitmap resultImage = new Bitmap(inputImage);
            const int maxRgb = 255;

            for (int y = 0; y < resultImage.Height; ++y)
            {
                for (int x = 0; x < resultImage.Width; ++x)
                {
                    Color pixel = resultImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(maxRgb - pixel.R, maxRgb - pixel.G, maxRgb - pixel.B);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        public static Bitmap ConvertToBlackAndWhite(Bitmap inputImage)
        {
            Bitmap resultImage = new Bitmap(inputImage);
            const double coeffR = 0.3;
            const double coeffG = 0.59;
            const double coeffB = 0.11;

            for (int y = 0; y < resultImage.Height; ++y)
            {
                for (int x = 0; x < resultImage.Width; ++x)
                {
                    Color pixel = resultImage.GetPixel(x, y);
                    byte rgb = getByte(pixel.R * coeffR + pixel.G * coeffG + pixel.B * coeffB);
                    Color newColor = Color.FromArgb(rgb, rgb, rgb);

                    resultImage.SetPixel(x, y, newColor);
                }
            }

            return resultImage;
        }

        static void Main(string[] args)
        {
            Bitmap image = new Bitmap("..\\..\\image.jpg");

            Bitmap blackAndWhiteImage = ConvertToBlackAndWhite(image);
            blackAndWhiteImage.Save("outBlackAndWhite.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("blackAndWhiteImage Ok!");

            Bitmap invertedColorImage = InvertColor(image);
            invertedColorImage.Save("outInvertedColor.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("invertedColorImage Ok!");

            double[,] blurMatrix =
            {
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 },
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 },
                { 1.0 / 9,  1.0 / 9,  1.0 / 9 }
            };

            Bitmap bluredImage = Convolution(image, blurMatrix);
            bluredImage.Save("outBlured.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("bluredImage Ok!");

            double[,] sharpnessMatrix = 
            {
                {  0, -1,  0 },
                { -1,  5, -1 },
                {  0, -1,  0 }
            };

            Bitmap sharpedImage = Convolution(image, sharpnessMatrix);
            sharpedImage.Save("outSharped.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("sharpedImage Ok!");

            double[,] stampingMatrix =
            {
                {  0,  1, 0 },
                { -1,  0, 1 },
                {  0, -1, 0 }
            };

            Bitmap stampedImage = Convolution(blackAndWhiteImage, stampingMatrix);
            stampedImage.Save("outStamped.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("stampedImage Ok!");

            Console.ReadLine();
        }
    }
}
