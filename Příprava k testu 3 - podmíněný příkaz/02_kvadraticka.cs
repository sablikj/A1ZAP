using System;

namespace Priklady
{
    class Program
    {
        static void Main(string[] args)
        {
            // (x - 3)(x - 3) = 1x^2 -6x + 9
            // (x - 2)(x - 3) = 1x^2 -5x + 6
            // (x - x1)(x - x2) = (ax^2 + bx + c)

            double a = 5.0;
            double b = -6.0;
            double c = 9.0;

            // napiste podminku ze a neni 0
            // pokud neni, tak pokracujte ve vypoctu
            // jinak napiste ze rovnice neni kvadraticka

            if (a != 0.0)
            {
                double D = (b * b) - (4 * a * c);

                // napiste podminku, jestli je 
                // D vetsi nez 0, rovno 0 a nebo mensi nez 0 
                if (D > 0)
                {
                    double v = Math.Sqrt(D);

                    double x1 = (-b + v) / (2 * a);
                    double x2 = (-b - v) / (2 * a);

                    Console.WriteLine($"x1 = {x1} x = {x2}");
                }
                else if (D == 0)
                {
                    double x = (-b) / (2 * a);

                    Console.WriteLine($"x1 = {x}");
                }
                else
                {
                    Console.WriteLine("Nema reseni v oboru realnych cisel");
                }
            }
            else
            {
                Console.WriteLine("rovnice neni kvadraticka");
            }
        }
    }
}
