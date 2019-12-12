using System;

namespace Priprava
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { 1, 2, 7, 5, 6, 3, 8 };
            Console.WriteLine(string.Join(",", pole));

            // pomoci cyklu for zmente poradi prvku pole aby byly pozpatku

            int prvniIndex = 0;
            int posledniIndex = pole.Length - 1;
            int n = pole.Length / 2;

            for (int i = 0; i < n; i++)
            {
                int tmp = pole[posledniIndex];
                pole[posledniIndex] = pole[prvniIndex];
                pole[prvniIndex] = tmp;

                ++prvniIndex;
                --posledniIndex;
            }

            Console.WriteLine(string.Join(",", pole));

            for (int i = 0, j = pole.Length - 1; i < pole.Length / 2; i++, j--)
            {
                int tmp = pole[j];
                pole[j] = pole[i];
                pole[i] = tmp;
            }

            Console.WriteLine(string.Join(",", pole));

            // prvky budou v poradi 8,3,6,5,7,2,1

            Console.ReadKey();
        }
    }
}