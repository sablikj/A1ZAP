using System;

namespace Priklady
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mame tri promenne
            int a = 2;
            int b = 5;
            int c = 7;

            // Vypiste hodnotu nejvetsi promenne

            // Reseni s logickym operatorem &&
            if ((a > b) && (a > c))
            {
                Console.WriteLine(a);
            }
            else if (b > c)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(c);
            }

            // reseni pouze s podminenym prikazem
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(c);
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(c);
                }
            }

            // Bonus:
            // Seradte hodnoty trech promennych
            // Postupne prohazujeme hodnoty promennych
            if (a < b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }

            if (b < c)
            {
                int tmp = b;
                b = c;
                c = tmp;
            }

            if (a < b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }
        }
    }
}
