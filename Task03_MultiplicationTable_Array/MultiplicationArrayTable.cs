using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03_MultiplicationTable_Array
{
    class MultiplicationArrayTable
    {
        static int[][] GetMultiplicationTable(int minX, int maxX, int minY, int maxY)
        {
            int[][] multiplicationTable = new int[maxY - minY + 1][];

            int xSize = maxX - minX + 1;

            int yIndex = 0;
            for (int i = minY; i <= maxY; ++i)
            {
                multiplicationTable[yIndex] = new int[xSize];

                int xIndex = 0;
                for (int j = minX; j <= maxX; ++j)
                {
                    multiplicationTable[yIndex][xIndex] = i * j;
                    ++xIndex;
                }

                ++yIndex;
            }

            return multiplicationTable;
        }

        static int[] GetArray(int min, int max)
        {
            int[] array = new int[max - min + 1];

            int index = 0;
            for (int i = min; i <= max; ++i)
            {
                array[index] = i;
                ++index;
            }

            return array;
        }

        static void PrintRow(int[] values, int[] valueLengthes)
        {
            for (int i = 0; i < values.Length; ++i)
            {  
                Console.Write(" {0," + valueLengthes[i] + "}", values[i]);
            }            
        }

        static void PrintMultiplicationTable(int[][] multiplicationTable, int[] xArray, int[] yArray)
        {
            int leftColumnLength = yArray[yArray.Length-1].ToString().Length;
            int lineLength = 0;
            int[] maxLength = new int[xArray.Length];
            for(int i=0;i<xArray.Length;++i)
            {
                maxLength[i]=multiplicationTable[yArray.Length-1][i].ToString().Length;
                lineLength += maxLength[i] + 1;
            }
            lineLength++;

            StringBuilder sb = new StringBuilder();
            sb.Append("+");
            for (int i = 0; i < lineLength; ++i)
            {
                sb.Append("-");
            }
            sb.Append("+");
            string line = sb.ToString();

            Console.Write(" {0," + leftColumnLength + "}  ", "");
            PrintRow(xArray, maxLength);
            Console.WriteLine();

            Console.Write(" {0," + leftColumnLength + "} ", "");
            Console.WriteLine(line);

            for (int i = 0; i < yArray.Length; i++)
            {
                Console.Write(" {0," + leftColumnLength + "} |", yArray[i]);
                PrintRow(multiplicationTable[i], maxLength);
                Console.WriteLine(" |");
            }
           
            Console.Write(" {0," + leftColumnLength + "} ", "");
            Console.WriteLine(line);
        }

        static void Main(string[] args)
        {
            int xMin =0;
            int xMax =0; 
            int yMin=0;
            int yMax=0;

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
            }
            while(xMin >= xMax);   
            
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
            }
            while(yMin >= yMax);

            int[][] table = GetMultiplicationTable(xMin,xMax,yMin,yMax);
            int[] xArray = GetArray(xMin,xMax);
            int[] yArray = GetArray(yMin,yMax);

            Console.WriteLine();
            PrintMultiplicationTable(table, xArray, yArray);

            Console.ReadLine();
        }
    }
}
