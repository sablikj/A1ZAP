using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stiskni klavesu q");

        znovu:
            char znak = Console.ReadKey().KeyChar;

            if(znak != 'q')
            {
                Console.WriteLine();
                Console.WriteLine("Mas zadat q");
                goto znovu;
            }

            Console.WriteLine("zadal jsi q, vyborne");
            Console.ReadKey();
        }
    }
}
