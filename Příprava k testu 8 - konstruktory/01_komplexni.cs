using System;

namespace Test
{
    struct Komplexni
    {
        public double re;
        public double im;

        public Komplexni(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Komplexni c1 = new Komplexni(2.0, 3.0);
            Console.WriteLine($"Komplexni cislo ma hodnotu {c1.re} + {c1.im}i");
        }
    }
}
