using System;

namespace MujDruhyProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mame vysledky dvou testu t1 a t2
            double t1 = 40.0;
            double t2 = 70.0;

            Console.WriteLine($"test1: {t1} test2: {t2}");
            
            bool vysledek;

            // Napiste vyraz ktery vrati true, pokud student splnil alespon jeden ze dvou testu za vice nez 45 bodu
            vysledek = t1 > 45.0 || t2 > 45.0;

            Console.WriteLine($"Splnil alespon jeden test (True ano, False ne): {vysledek}");

            // Napiste pvyraz ktery vrati true, pokud student nesplnil zadny ze dvou testu za vice nez 45 bodu
            vysledek = t1 <= 45.0 && t2 <= 45.0;

            Console.WriteLine($"Nesplnil zadny test (True ano, False ne): {vysledek}");

            // Napiste vyraz ktery vrati true, pokud student splnil kazdy ze dvou testu za vice nez 45 bodu
            vysledek = t1 > 45.0 && t2 > 45.0;

            Console.WriteLine($"Splnil oba testy (True ano, False ne): {vysledek}");

            // Prepiste vyraz ktery vrati true, pokud je alespon jeden ze dvou testu za vice nez 45 bodu s pouzitim negace a AND
            vysledek = !(t1 <= 45.0 && t2 <= 45.0); // Otestujeme zda nebyl napsany zadny test a vysledek potom znegujeme

            Console.WriteLine($"Neplati ze nesplnil oba testy (True ano, False ne): {vysledek}");

            Console.ReadKey();
        }
    }
}