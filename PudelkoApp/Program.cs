using System.Globalization;
using PudelkoLibrary;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pudelko(2.5, 9.321, 0.1, unit: UnitOfMeasure.meter);
            Console.WriteLine(p.Volume.ToString("F9"));
            Console.WriteLine(p.Field.ToString("F6"));
        }
    }
}