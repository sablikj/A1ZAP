using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spocitejte faktorial cisla n
            // n!
            int n = 6;
            

            int f = n--;
            for (; n > 1; n--)
            {
                f = f * n;
            }

            Console.WriteLine(f);

            Console.ReadKey();
        }
    }
}
