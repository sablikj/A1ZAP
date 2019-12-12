using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // s pomoci cyklu while vypiste 
            // na konzoli cisla 1,2,3,4,5,6,7,8,9
            int i = 1;
            while (i < 10) 
            {
                Console.WriteLine(i);
                i++;
            }
            
            // cekani na stisk klavesy q
            Console.WriteLine("Stiskni klavesu q");
            char znak;

            do
            {
                znak = Console.ReadKey().KeyChar;
                if(znak != 'q')
                {
                    Console.WriteLine();
                    Console.WriteLine("Mas zadat q");
                }
            }
            while (znak != 'q');
           
            Console.WriteLine("zadal jsi q, vyborne");
            Console.ReadKey();
        }
    }
}
