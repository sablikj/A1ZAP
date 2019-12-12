using System;

namespace Test10
{
    class Kruh
    {
        private double _polomer;

        public double Polomer
        {
            get { return _polomer; }
            set { _polomer = value; }
        }
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
