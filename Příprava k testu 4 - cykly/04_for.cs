using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            // s pomoci cyklu for vypiste na konzoli 
            // cisla 1,2,3,4,5,6,7,8,9
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // cisla 10,9,8,7,6,5,4,3,2,1
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }

            // cisla 10,20,30,40,50,60,70,80,90,100
            for (int i = 10; i <= 100; i = i + 10)
            {
                Console.WriteLine(i);
            }

            // cisla 10,100,1000,10000,100000
            for (int i = 10; i <= 100000; i = i * 10)
            {
                Console.WriteLine(i);
            }

            // cisla 256,128,64,32,16,8,4,2,1
            for (int i = 256; i >= 1; i = i / 2)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
