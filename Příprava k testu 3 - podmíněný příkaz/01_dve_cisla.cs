using System;

namespace Priklady
{
    class Program
    {
        static void Main(string[] args)
        {
            // mame dve promenne
            int x = 2;
            int y = 5;
           
            // vypiste hodnotu vetsi z promennych
            if(x > y)
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine(y);
            }

            // seradte hodnoty v promennych tak aby v promenne x bylo vetsi cislo nez v promenne x
            if(x < y)
            {
                int tmp = x;
                x = y;
                y = tmp;
            }
        }
    }
}