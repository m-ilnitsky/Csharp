using System;

namespace Task10_BuildEvents
{
    internal class Program
    {
        private static void Main()
        {
            #region Initialization
#if DEBUG
            const int size = 8;
#endif
#if RELEASE
            const int size = 16;
#endif
#if MY_RELEASE
            const int size = 29;
#endif
            #endregion

            #region Write
            var cellWidth = (size * size).ToString().Length;
            var pattern = " {0," + cellWidth + "}";

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (i <= j)
                    {
                        Console.Write(pattern, (i + 1) * (j + 1));
                    }
                    else
                    {
                        Console.Write(pattern, "");
                    }
                }
                Console.WriteLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
