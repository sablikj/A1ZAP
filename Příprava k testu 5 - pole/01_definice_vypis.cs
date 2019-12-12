using System;

namespace Priprava
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole = new int[3] { 1, 2, 3 };
            Console.WriteLine(pole[0]);
            Console.WriteLine(pole[1]);
            Console.WriteLine(pole[2]);

            int[] pole1 = new int[3]; // prvky budou mit hodnotu 0
            int[] pole2 = new int[] { 1, 2, 3 };
            int[] pole3 = new[] { 1, 2, 3 };
            int[] pole4 = { 1, 2, 3 };

            // pole ma 10 prvku, jaky bude
            // prvni index prvku v poli? 0
            // posledni index prvku v poli? 9
            for (int i = 0; i < pole.Length; i++)
            {
                int prvek = pole[i];
                Console.WriteLine($"prvek pole s indexem {i} ma hodnotu {prvek}");
            }
            // napiste kod, ktery spocita a vypise soucet prvku v poli
            foreach (int prvek in pole)
            {
                Console.WriteLine(prvek);
            }
        }
    }
}