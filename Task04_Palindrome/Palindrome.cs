using System;

namespace Task04_Palindrome
{
    class Palindrome
    {
        static bool IsPalindrome(string inputString)
        {
            for (int i = 0, j = inputString.Length - 1; i < j; ++i, --j)
            {
                while (i < j && !char.IsLetterOrDigit(inputString[i]))
                {
                    ++i;
                }

                while (i < j && !char.IsLetterOrDigit(inputString[j]))
                {
                    --j;
                }

                if (char.ToLower(inputString[i]) != char.ToLower(inputString[j]))
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            string[] inputStrings = {
                "Аргентина манит негра",
                "А роза упала на лапу Азора",
                "Я иду с мечем судия",
                "Я - арка края",
                "О, лета тело!",
                "Я не палиндром!",
                "Тоже не палиндром.."
            };

            foreach (string str in inputStrings)
            {
                Console.WriteLine(str);
                if (IsPalindrome(str))
                {
                    Console.WriteLine("^ это палиндром");
                }
                else
                {
                    Console.WriteLine("^ строка не является палиндромом");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
