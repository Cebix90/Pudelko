using System.Globalization;
using PudelkoLibrary;

namespace PudelkoApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // Sorting boxes
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

            // Introduction of individual implementations
            Console.WriteLine("\nIntroduction of individual implementations");

            var p1 = new Pudelko(2.5, 9.321, 0.1);
            var p2 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
            var p3 = new Pudelko(2.5, 9.32, 0.1, UnitOfMeasure.centimeter);
            var p4 = new Pudelko(2500, 9321, 100, UnitOfMeasure.milimeter);

            // ToString implementation
            string s1 = p1.ToString();
            string s2 = p1.ToString("m");
            string s3 = p1.ToString("cm");
            string s4 = p1.ToString("mm");
            Console.WriteLine($"p1 = {s1}");
            Console.WriteLine($"p1 = {s2}");
            Console.WriteLine($"p1 = {s3}");
            Console.WriteLine($"p1 = {s4}");

            // Volume and Field properties
            Console.WriteLine($"\nVolume = {p1.Volume} m\u00B3");
            Console.WriteLine($"Field = {p1.Field} m\u00B2");

            // Equals
            Console.WriteLine($"\np1 == p2: {p1 == p2}");
            Console.WriteLine($"p1 != p2: {p1 != p2}");
            Console.WriteLine($"Equals(p1, p3): {Equals(p1, p3)}");
            Console.WriteLine($"p1.Equals(p4): {p1.Equals(p4)}\n");

            // Operator +

            // Conversion explicit and implicit
            var explicitArr = (double[])p1;
            Console.WriteLine($"p1 dimensions: {String.Join(" × ", explicitArr.Select(e => e.ToString()))}");
            Pudelko p5 = (20, 30, 40);
            Console.WriteLine($"{p5.ToString()}\n");

            // Indexer and foreach loop
            Console.WriteLine(p1[0]);
            Console.WriteLine(p1[1]);
            Console.WriteLine(p1[2]);

            Console.WriteLine();

            foreach (var dimension in p1)
            {
                Console.WriteLine(dimension);
            }

            // Parsing
            var s = "2.5 cm × 9.32 cm × 0.1 cm";
            Console.WriteLine($"\nstring \"{s}\" == to p3: {Pudelko.Parse(s) == p3}");

            // Compress
            Console.WriteLine($"Dimensions of box p1 after compression: {p1.Kompresuj().ToString()}");
        }

        public static Pudelko Kompresuj(this Pudelko p)
        {
            double volume = p.Volume;

            double a = Math.Pow(volume, 1.0 / 3.0);

            return new Pudelko(a,a,a);
        }
    }
}