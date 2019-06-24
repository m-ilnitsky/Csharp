using System;
using System.Text;

namespace Task03_MultiplicationTable_Array
{
    internal class MultiplicationArrayTable
    {
        private static int[,] GetMultiplicationTable(int minX, int maxX, int minY, int maxY)
        {
            var multiplicationTable = new int[maxY - minY + 1, maxX - minX + 1];

            var yIndex = 0;
            for (var i = minY; i <= maxY; ++i)
            {
                var xIndex = 0;
                for (var j = minX; j <= maxX; ++j)
                {
                    multiplicationTable[yIndex, xIndex] = i * j;
                    ++xIndex;
                }

                ++yIndex;
            }

            return multiplicationTable;
        }

        private static int[] GetArray(int min, int max)
        {
            var array = new int[max - min + 1];

            var index = 0;
            for (var i = min; i <= max; ++i)
            {
                array[index] = i;
                ++index;
            }

            return array;
        }

        private static void PrintMultiplicationTable(int[,] multiplicationTable, int[] xArray, int[] yArray)
        {
            var leftColumnLength = yArray[yArray.Length - 1].ToString().Length;
            var lineLength = 0;
            var maxLength = new int[xArray.Length];
            for (var i = 0; i < xArray.Length; ++i)
            {
                maxLength[i] = multiplicationTable[yArray.Length - 1, i].ToString().Length;
                lineLength += maxLength[i] + 1;
            }
            lineLength++;

            var sb = new StringBuilder();
            sb.Append("+");
            for (var i = 0; i < lineLength; ++i)
            {
                sb.Append("-");
            }
            sb.Append("+");
            var line = sb.ToString();

            Console.Write(" {0," + leftColumnLength + "}  ", "");
            for (var i = 0; i < xArray.Length; ++i)
            {
                Console.Write(" {0," + maxLength[i] + "}", xArray[i]);
            }
            Console.WriteLine();

            Console.Write(" {0," + leftColumnLength + "} ", "");
            Console.WriteLine(line);

            for (var i = 0; i < yArray.Length; i++)
            {
                Console.Write(" {0," + leftColumnLength + "} |", yArray[i]);
                for (var j = 0; j < maxLength.Length; ++j)
                {
                    Console.Write(" {0," + maxLength[j] + "}", multiplicationTable[i, j]);
                }
                Console.WriteLine(" |");
            }

            Console.Write(" {0," + leftColumnLength + "} ", "");
            Console.WriteLine(line);
        }

        private static void Main()
        {
            int xMin, xMax, yMin, yMax;

            do
            {
                Console.WriteLine();
                Console.Write("Введите начальное значение множителей по X: ");
                xMin = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите конечное значение множителей по X: ");
                xMax = Convert.ToInt32(Console.ReadLine());

                if (xMin >= xMax)
                {
                    Console.WriteLine("ОШИБКА: Начальное значение должно быть меньше конечного!");
                }
                if (xMin < 1)
                {
                    Console.WriteLine("ОШИБКА: Начальное значение должно быть не меньше единицы!");
                }
            }
            while (xMin >= xMax || xMin < 1);

            do
            {
                Console.WriteLine();
                Console.Write("Введите начальное значение множителей по Y: ");
                yMin = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите конечное значение множителей по Y: ");
                yMax = Convert.ToInt32(Console.ReadLine());

                if (yMin >= yMax)
                {
                    Console.WriteLine("ОШИБКА: Начальное значение должно быть меньше конечного!");
                }
                if (yMin < 1)
                {
                    Console.WriteLine("ОШИБКА: Начальное значение должно быть не меньше единицы!");
                }
            }
            while (yMin >= yMax || yMin < 1);

            var table = GetMultiplicationTable(xMin, xMax, yMin, yMax);
            var xArray = GetArray(xMin, xMax);
            var yArray = GetArray(yMin, yMax);

            Console.WriteLine();
            PrintMultiplicationTable(table, xArray, yArray);

            Console.ReadLine();
        }
    }
}
