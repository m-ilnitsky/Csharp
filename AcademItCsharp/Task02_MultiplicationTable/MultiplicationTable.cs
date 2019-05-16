using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_MultiplicationTable
{
    class MultiplicationTable
    {
        static void Main(string[] args)
        {
            uint min = 2;
            uint max = 28;
            Console.Write("Введите максимальное число таблицы умножения (от {0} до {1}): ", min, max);
            uint maxNumber = Convert.ToUInt32(Console.ReadLine());
            if (maxNumber < min)
            {
                Console.WriteLine("ОШИБКА: Число меньше {0}! Поэтому бдем считать, что оно равно {0}", min);
                maxNumber = min;
            }
            else if (maxNumber > max)
            {
                Console.WriteLine("ОШИБКА: Число больше {0}! Поэтому бдем считать, что оно равно {0}", max);
                maxNumber = max;
            }

            uint lineLength = 0;
            for (uint j = 1; j <= maxNumber; j++)
            {
                uint maxLength = (uint)Convert.ToString(maxNumber * j).Length;
                lineLength += maxLength + 1;

                if (j == 1)
                {
                    Console.Write(" {0," + maxLength + "}  ", "");
                }

                Console.Write(" {0," + maxLength + "}", j);
            }
            Console.WriteLine();

            StringBuilder sb = new StringBuilder();
            for (uint i = 0; i < lineLength; i++)
            {
                sb.Append("-");
            }

            uint prefixLength = (uint)Convert.ToString(maxNumber).Length;
            Console.Write(" {0," + prefixLength + "} +", "");
            Console.Write(sb.ToString());
            Console.WriteLine("-+");

            for (uint i = 1; i <= maxNumber; i++)
            {
                for (uint j = 1; j <= maxNumber; j++)
                {
                    uint maxLength = (uint)Convert.ToString(maxNumber * j).Length;

                    if (j == 1)
                    {
                        Console.Write(" {0," + maxLength + "} |", i * j);
                    }

                    Console.Write(" {0," + maxLength + "}", i * j);
                }
                Console.WriteLine(" |");
            }

            Console.Write(" {0," + prefixLength + "} +", "");
            Console.Write(sb.ToString());
            Console.WriteLine("-+");

            Console.ReadLine();
        }
    }
}
