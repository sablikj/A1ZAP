using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 77;
            int zbytek = x % 5; // modulo, zbytek po celociselnem deleni
            if(zbytek == 0)
            {
                Console.WriteLine("cislo je delitelne 5");
            }

            // vypiste cisla od 0 do 100 delitelna 5 nebo 3
            // 0, 3, 5, 6, 9, 10 .... 100

            for (int i = 0; i < 100; i++)
            {
                if((i % 5 == 0) || (i % 3 == 0))
                {
                    Console.WriteLine(i);
                }
            }

            Console.ReadKey();
        }
    }
}
