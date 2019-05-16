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
            const int MIN = 2;
            const int MAX = 28;
            Console.Write("Введите максимальное число таблицы умножения (от {0} до {1}): ", MIN, MAX);
            int maxNumber = Convert.ToInt32(Console.ReadLine());
            if (maxNumber < MIN)
            {
                Console.WriteLine("ОШИБКА: Число меньше {0}! Поэтому будем считать, что оно равно {0}", MIN);
                maxNumber = MIN;
            }
            else if (maxNumber > MAX)
            {
                Console.WriteLine("ОШИБКА: Число больше {0}! Поэтому будем считать, что оно равно {0}", MAX);
                maxNumber = MAX;
            }

            int lineLength = 0;
            for (int j = 1; j <= maxNumber; j++)
            {
                int maxLength = Convert.ToString(maxNumber * j).Length;
                lineLength += maxLength + 1;

                if (j == 1)
                {
                    Console.Write(" {0," + maxLength + "}  ", "");
                }

                Console.Write(" {0," + maxLength + "}", j);
            }
            Console.WriteLine();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lineLength; i++)
            {
                sb.Append("-");
            }

            int prefixLength = Convert.ToString(maxNumber).Length;
            Console.Write(" {0," + prefixLength + "} +", "");
            Console.Write(sb.ToString());
            Console.WriteLine("-+");

            for (int i = 1; i <= maxNumber; i++)
            {
                for (int j = 1; j <= maxNumber; j++)
                {
                    int maxLength = Convert.ToString(maxNumber * j).Length;

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
