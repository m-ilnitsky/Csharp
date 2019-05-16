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

            int yIndex = 0;
            for (int i = minY; i <= maxY; ++i)
            {
                multiplicationTable[yIndex] = new int[maxX - minX + 1];

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

        static void PrintMultiplicationTable(int[][] multiplicationTable, int[] xArray, int[] yArray)
        {
            
        }

        static void Main(string[] args)
        {
        }
    }
}
