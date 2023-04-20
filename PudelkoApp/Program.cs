using System.Globalization;
using PudelkoLibrary;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pudelko(3, 3, 0.5, unit: UnitOfMeasure.meter);
            var a = new Pudelko(3, 3, 0.5);
            var b = new Pudelko(3, 0.5, 3, unit: UnitOfMeasure.meter);
            var c = new Pudelko(3, 3, 3, unit: UnitOfMeasure.meter);
            var d = new Pudelko(300, 300, 50, unit: UnitOfMeasure.centimeter);
            var e = new Pudelko(500, 3000, 3000, unit: UnitOfMeasure.milimeter);
            var f = new Pudelko();
            var g = new Pudelko();
            var h = new Pudelko(0.1);
            var i = new Pudelko(0.1, 0.1, 0.1);

            Console.WriteLine(p == a);
            Console.WriteLine(p == b);
            Console.WriteLine(p == c);
            Console.WriteLine(p != c);
            Console.WriteLine(p == d);
            Console.WriteLine(b == e);

            Console.WriteLine(b.Equals(e));
            Console.WriteLine(Equals(b,e));

            Console.WriteLine(f != g);
            Console.WriteLine(f == h);
            Console.WriteLine(f == i);
        }
    }
}