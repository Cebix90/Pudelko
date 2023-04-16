namespace PudelkoLibrary
{
    public class Pudelko
    {

        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }
        public UnitOfMeasure Unit { get; init; }

        public Pudelko(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
    
