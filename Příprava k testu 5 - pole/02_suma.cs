using System;
using System.Linq;

namespace Priprava
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { 5, 7, 1, 2, 3 };

            int suma = 0;
            foreach (int prvek in pole)
            {
                Console.WriteLine(prvek);
                suma += prvek;
            }

            Console.WriteLine($"soucet prvku v poli je {suma}");
            // alternativne muzeme pouzit LINQ metodu:
            suma = pole.Sum();
        }
    }
}