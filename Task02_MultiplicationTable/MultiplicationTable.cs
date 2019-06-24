using System;
using System.Text;

namespace Task02_MultiplicationTable
{
    internal class MultiplicationTable
    {
        private static void Main()
        {
            const int min = 2;
            const int max = 28;

            Console.Write("Введите максимальное число таблицы умножения (от {0} до {1}): ", min, max);
            var maxNumber = Convert.ToInt32(Console.ReadLine());

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

            var lineLength = 0;
            string pattern;

            for (var i = 1; i <= maxNumber; i++)
            {
                var maxLength = Convert.ToString(maxNumber * i).Length;
                lineLength += maxLength + 1;

                pattern = " {0," + maxLength + "}";

                if (i == 1)
                {
                    Console.Write(pattern + "  ", "");
                }

                Console.Write(pattern, i);
            }
            Console.WriteLine();

            var sb = new StringBuilder();
            for (var i = 0; i < lineLength; i++)
            {
                sb.Append("-");
            }

            var prefixLength = Convert.ToString(maxNumber).Length;
            var line = sb.ToString();

            pattern = " {0," + prefixLength + "} +";

            Console.Write(pattern, "");
            Console.Write(line);
            Console.WriteLine("-+");

            for (var i = 1; i <= maxNumber; i++)
            {
                var pattern2 = " {0," + Convert.ToString(maxNumber).Length + "} |";
                Console.Write(pattern2, i);

                for (var j = 1; j <= maxNumber; j++)
                {
                    pattern2 = " {0," + Convert.ToString(maxNumber * j).Length + "}";
                    Console.Write(pattern2, i * j);
                }
                Console.WriteLine(" |");
            }

            Console.Write(pattern, "");
            Console.Write(line);
            Console.WriteLine("-+");

            Console.ReadLine();
        }
    }
}
