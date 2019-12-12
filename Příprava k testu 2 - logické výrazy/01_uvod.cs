using System;

namespace MujDruhyProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;

            bool vysledek;
            
            vysledek = x == y; // rovnost
            vysledek = x != y; // rovnost
            vysledek = x < y; // rovnost
            vysledek = x > y; // rovnost
            vysledek = x >= y; // rovnost
            vysledek = x >= y; // rovnost

            vysledek = (x < y) && (y == 3); // pravda pokud je x menší než y a zárověň y je rovno 3
            vysledek = (x < y) || (y == 2); // pravda pokud je x menší než y a nebo y je rovno 3
            vysledek = !(x < y); // operator !neguje vysledek predchozi operace, vyraz je pravda, pokud je x vetsi nebo rovno y

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
