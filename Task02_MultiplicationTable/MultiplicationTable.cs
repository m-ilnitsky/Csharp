using System;
using System.Text;

namespace Task02_MultiplicationTable
{
    class MultiplicationTable
    {
        static void Main(string[] args)
        {
            const int min = 2;
            const int max = 28;

            Console.Write("Введите максимальное число таблицы умножения (от {0} до {1}): ", min, max);
            int maxNumber = Convert.ToInt32(Console.ReadLine());

            if (maxNumber < min)
            {
                Console.WriteLine("ОШИБКА: Число меньше {0}! Поэтому будем считать, что оно равно {0}", min);
                maxNumber = min;
            }
            else if (maxNumber > max)
            {
                Console.WriteLine("ОШИБКА: Число больше {0}! Поэтому будем считать, что оно равно {0}", max);
                maxNumber = max;
            }

            Console.WriteLine();

            int lineLength = 0;
            for (int i = 1; i <= maxNumber; i++)
            {
                int maxLength = Convert.ToString(maxNumber * i).Length;
                lineLength += maxLength + 1;

                if (i == 1)
                {
                    Console.Write(" {0," + maxLength + "}  ", "");
                }

                Console.Write(" {0," + maxLength + "}", i);
            }
            Console.WriteLine();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lineLength; i++)
            {
                sb.Append("-");
            }

            int prefixLength = Convert.ToString(maxNumber).Length;
            string line = sb.ToString();

            Console.Write(" {0," + prefixLength + "} +", "");
            Console.Write(line);
            Console.WriteLine("-+");

            for (int i = 1; i <= maxNumber; i++)
            {
                Console.Write(" {0," + Convert.ToString(maxNumber).Length + "} |", i);

                for (int j = 1; j <= maxNumber; j++)
                {
                    Console.Write(" {0," + Convert.ToString(maxNumber * j).Length + "}", i * j);
                }
                Console.WriteLine(" |");
            }

            Console.Write(" {0," + prefixLength + "} +", "");
            Console.Write(line);
            Console.WriteLine("-+");

            Console.ReadLine();
        }
    }
}
