using System;

namespace Test
{
    class Program
    {
        struct Obdelnik
        {
            public double a;
            public double b;

            public void ZmenRozmery(double a, double b)
            {
                this.a = a;
                this.b = b;
            }

            public double VratObvod()
            {
                return a + b;
            }

            public double VratObsah()
            {
                return a * b;
            }
        }

        static void Main(string[] args)
        {
            Obdelnik o1 = new Obdelnik(); // rozmery budou 0,0
            o1.ZmenRozmery(2.0, 3.0);
            double obvod = o1.VratObvod();
            double obsah = o1.VratObsah();

            Console.WriteLine($"Obdelnik ma rozmery {o1.a}, {o1.b} a jeho obvod je {obvod} a obsah {obsah}");
        }
    }
}