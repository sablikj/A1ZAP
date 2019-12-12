using System;

namespace Test10
{
    class Kruh
    {
        public double Polomer { get; set; }
    }   

    class Program
    {
        static void Main(string[] args)
        {
            Kruh kruh = new Kruh();
            kruh.Polomer = 10;
            Console.WriteLine(kruh.Polomer);
        }
    }
}