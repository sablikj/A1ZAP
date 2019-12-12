using System;

namespace MujDruhyProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mame vysledky tri testu t1 a t2
            double t1 = 30.0;
            double t2 = 40.0;
            double t3 = 70.0;

            Console.WriteLine($"test1: {t1}, test2: {t2}, test3: {t3}");
            bool vysledek;

            // Napiste vyraz ktery vrati true, pokud student splnil alespon jeden ze tri testu za vice nez 45 bodu
            vysledek = (t1 > 45.0) || (t2 > 45.0) || (t3 > 45.0);

            Console.WriteLine($"Splnil alespon jeden test ze tri (True ano, False ne): {vysledek}");

            // Napiste vyraz ktery vrati true, pokud student splnil vsechny tri testy, kazdy za vice nez 45 bodu
            vysledek = (t1 > 45.0) && (t2 > 45.0) && (t3 > 45.0);

            Console.WriteLine($"Splnil vsechny tri testy (True ano, False ne): {vysledek}");

            // Napiste vyraz ktery vrati true, pokud student splnil alespon dva ze tri testu za vice nez 45 bodu
            vysledek = ((t1 > 45.0) && (t2 > 45.0)) || ((t1 > 45.0) && (t3 > 45.0)) || ((t2 > 45.0) && (t3 > 45.0));

            Console.WriteLine($"Splnil alespon dva testy ze tri (True ano, False ne): {vysledek}");

            Console.ReadKey();
        }
    }
}