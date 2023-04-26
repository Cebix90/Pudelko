using System.Globalization;
using PudelkoLibrary;

namespace PudelkoApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            /*var p = new Pudelko(8, 4, 2, unit: UnitOfMeasure.meter);
            var a = new Pudelko(5, 3, 2);

            var p3 = p + a;
            Console.WriteLine(p3.Volume.ToString());
            Console.WriteLine(p3.A);
            Console.WriteLine(p3.B);
            Console.WriteLine(p3.C);
            Console.WriteLine();

            var b = new Pudelko(5, 4, 3);
            var c = new Pudelko(6, 5, 4);

            var p4 = b + c;
            Console.WriteLine(p4.Volume);
            Console.WriteLine(p4.A);
            Console.WriteLine(p4.B);
            Console.WriteLine(p4.C);*/

            /*string s = "2.500 cm × 9.321 cm × 0.100 cm";

            var p = new Pudelko(2.5, 9.321, 0.1);
            var p1 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
            var p2 = new Pudelko(2.5, 9.32, 0.1, UnitOfMeasure.centimeter);
            var p3 = new Pudelko(2500, 9321, 100, UnitOfMeasure.milimeter);

            var ps = Pudelko.Parse(s);

            Console.WriteLine(p == ps);
            Console.WriteLine(p == p1);
            Console.WriteLine(p1 == ps);
            Console.WriteLine(p2 == ps);
            Console.WriteLine(p3 == ps);*/

            var p = new Pudelko(2.03, 4.3, 9.66, UnitOfMeasure.meter);
            Console.WriteLine(p.ToString("mm"));
            Console.WriteLine(p.Volume);

            var pk = Kompresuj(p);
            Console.WriteLine(pk.ToString("mm"));
            Console.WriteLine(pk.Volume);
        }

        public static Pudelko Kompresuj(this Pudelko p)
        {
            double volume = p.Volume;

            double a = Math.Pow(volume, 1.0 / 3.0);

            return new Pudelko(a,a,a);
        }
    }
}