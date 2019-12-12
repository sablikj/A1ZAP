using System;

namespace Test
{
    struct Bod
    {
        public double X;
        public double Y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bod b1;
            b1.X = 2;
            b1.Y = 3;

            Bod b2 = b1;

            b1.X = 0;
            b1.Y = 0;

            Console.WriteLine($"Bod b1 ma souradnice {b1.X} a {b1.Y}");
            Console.WriteLine($"Bod b2 ma souradnice {b2.X} a {b2.Y}");
        }
    }
}