using System;

namespace Test
{
    class HypotecniKalkulacka
    {
        public int pocetLetSplaceni;
        public double rocniUrokProcenta;
        public double dluh; // dluh

        public HypotecniKalkulacka(int pocetLetSplaceni, double rocniUrokProcenta, double dluh)
        {
            this.pocetLetSplaceni = pocetLetSplaceni;
            this.rocniUrokProcenta = rocniUrokProcenta;
            this.dluh = dluh;
        }

        public double VratSplatku()
        {
            int n = pocetLetSplaceni * 12; // pocet mesicu splaceni
            double i = rocniUrokProcenta / (12 * 100); // desetinne cislo

            double v = 1 / (1 + i);
            double splatka = (i * dluh) / (1 - Math.Pow(v, n));

            return splatka;
        }
    }
  

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej pocet let splaceni:");
            if(!int.TryParse(Console.ReadLine(), out int pocetLet))
            {
                return;
            }

            Console.WriteLine("Zadej rocni urok v procentech:");
            if (!double.TryParse(Console.ReadLine(), out double urok))
            {
                return;
            }

            Console.WriteLine("Zadej vysi dluhu:");
            if (!double.TryParse(Console.ReadLine(), out double dluh))
            {
                return;
            }

            HypotecniKalkulacka kalkulacka = new HypotecniKalkulacka(pocetLet, urok, dluh);
            double splatka = kalkulacka.VratSplatku();

            Console.WriteLine($"Splatka je {splatka:F2}");

            Console.ReadKey(true);
        }
    }
}