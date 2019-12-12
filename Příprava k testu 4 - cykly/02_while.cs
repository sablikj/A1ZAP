using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stiskni klavesu q");
            char znak;
            
            while ((znak = Console.ReadKey().KeyChar) != 'q') 
            {
                 Console.WriteLine();
                 Console.WriteLine("Mas zadat q");
            }
            
            Console.WriteLine("zadal jsi q, vyborne");
            Console.ReadKey();
        }
    }
}
