using System;

namespace Ukol
{
    class Zavodnik
    {
        public double cas;
        public string jmeno;

        public Zavodnik(double cas, string jmeno)
        {
            this.cas = cas;
            this.jmeno = jmeno;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej pocet zavodniku:");
            int.TryParse(Console.ReadLine(), out int pocetZavodniku);

            Console.WriteLine($"Pocet zavodniku je {pocetZavodniku}");
            Zavodnik[] zavodnici = new Zavodnik[pocetZavodniku];

            for (int i = 0; i < pocetZavodniku; i++)
            {
                Console.WriteLine("Zadej jmeno");
                string jmeno = Console.ReadLine();

                Console.WriteLine("Zadej cas");
                double.TryParse(Console.ReadLine(), out double cas);

                zavodnici[i] = new Zavodnik(cas, jmeno);
            }

            Zavodnik nejrychlejsi = zavodnici[0];

            double maximum = double.MinValue;
            double suma = 0.0;
            Console.WriteLine("Zavodnici");
            foreach (Zavodnik zavodnik in zavodnici)
            {
                Console.WriteLine($"{zavodnik.jmeno}: {zavodnik.cas:F2}");

                suma += zavodnik.cas;
                if(zavodnik.cas < nejrychlejsi.cas)
                {
                    nejrychlejsi = zavodnik;
                }
                
                if(zavodnik.cas > maximum)
                {
                    maximum = zavodnik.cas;
                }
            }
            double prumer = suma / pocetZavodniku;
            Console.WriteLine($"prumer: {prumer} minimum: {nejrychlejsi.cas}({nejrychlejsi.jmeno}) maximum: {maximum}");
            
           

            Console.ReadKey();
        }
    }
}
