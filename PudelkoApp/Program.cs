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

            /*var p = new Pudelko(2.03, 4.3, 9.66, UnitOfMeasure.meter);
            Console.WriteLine(p.ToString("mm"));
            Console.WriteLine(p.Volume);

            var pk = Kompresuj(p);
            Console.WriteLine(pk.ToString("mm"));
            Console.WriteLine(pk.Volume);*/

            var pudelka = new List<Pudelko>
            {
                new Pudelko(1.5, 2.0, 3.0),
                new Pudelko(200, 200, 200, UnitOfMeasure.centimeter),
                new Pudelko(1000, 1000, 5000, UnitOfMeasure.milimeter),
                new Pudelko(3.0, 1.5, 1.0, UnitOfMeasure.meter),
                new Pudelko(15, 300, 10, UnitOfMeasure.milimeter),
            };

            Console.WriteLine("Initial List in meters:");
            foreach (var p in pudelka)
            {
                Console.WriteLine(p.ToString());
            }

            Comparison<Pudelko> kryteriumSortowania = (p1, p2) =>
            {
                int result = p1.Volume.CompareTo(p2.Volume);
                if (result != 0) return result;

                result = p1.Field.CompareTo(p2.Field);
                if (result != 0) return result;

                return (p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C);
            };

            pudelka.Sort(kryteriumSortowania);

            Console.WriteLine("\nSorted List in meters:");
            foreach (var p in pudelka)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static Pudelko Kompresuj(this Pudelko p)
        {
            double volume = p.Volume;

            double a = Math.Pow(volume, 1.0 / 3.0);

            return new Pudelko(a,a,a);
        }
    }
}