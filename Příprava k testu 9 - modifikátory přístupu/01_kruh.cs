using System;

namespace Test9
{
    class Kruh
    {
        private double polomer;

        public double VratPolomer()
        {
            return polomer;
        }

        public void NastavPolomer(double polomer)
        {
            this.polomer = polomer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kruh kruh = new Kruh();
            //kruh.polomer = 10.0; // nelze prelozit protoze polomer je private
            //Console.WriteLine(kruh.polomer); // nelze prelozit protoze polomer je private
            kruh.NastavPolomer(10);
            Console.WriteLine(kruh.VratPolomer());
        }
    }
}
