using System;

namespace Task05_Range
{
    internal class RangeTester
    {
        private static void TestPoint(Range range, double point)
        {
            if (range.IsInside(point))
            {
                Console.WriteLine("Точка {0} принадлежит диапазону {1}.", point, range);
                return;
            }

            Console.WriteLine("Точка {0} НЕ принадлежит диапазону {1}.", point, range);
        }

        private static void Main()
        {
            var range1 = new Range(1, 15);
            var range2 = new Range(-1, -15);
            var range3 = new Range(15.7, -15.7);

            Console.WriteLine("Диапазон №1 : {0}", range1);
            Console.WriteLine("Диапазон №2 : {0}", range2);
            Console.WriteLine("Диапазон №3 : {0}", range3);
            Console.WriteLine();

            double[] points = { -15.7, -15, -1, 0, 1, 15, 15.7 };

            foreach (var point in points)
            {
                TestPoint(range1, point);
                TestPoint(range2, point);
                TestPoint(range3, point);
            }

            Console.ReadLine();
        }
    }
}
