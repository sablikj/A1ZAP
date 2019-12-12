using System;

namespace Test
{
    struct Obdelnik
    {
        public double a;
        public double b;

        public Obdelnik(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Obdelnik o1 = new Obdelnik(2.0, 3.0);
            Console.WriteLine($"Obdelnik ma rozmery {o1.a} x {o1.b}");
        }
    }
}
