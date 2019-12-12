using System;

namespace MujDruhyProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mame trojuhelnik dany delkami trech strank
            double a = 3.0;
            double b = 4.0;
            double c = 5.0;

            bool vysledek;

            // Napiste vyraz ktery vrati true, kdyz je trojuhelnik pravouhly, musi platit a^2 + b^2 = c^2 
            vysledek = a * a + b * b == c * c; // poznamka, diky chybam v zaukrouhlovanim nam v nekterych pripadech nemusi rovnost vychazet

            Console.WriteLine($"Je trojuhelnik pravouhly (True ano, False ne): {vysledek}");

            // Napiste vyraz ktery vrati true, kdyz trojuhelnik existuje, soucet delek dvou libovolnych stran je vzdy vetsi nez delka treti
            vysledek = (a + b > c) && (a + c > b) && (b + c > a);

            Console.WriteLine($"Existuje trojuhelnik (True ano, False ne): {vysledek}");

            Console.ReadKey();
        }
    }
}
