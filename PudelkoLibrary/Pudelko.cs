
namespace PudelkoLibrary
{
    public sealed class Pudelko
    {
        public double A
        {
            get { return (Unit == UnitOfMeasure.milimeter) ? A / 1000 : ((Unit == UnitOfMeasure.centimeter) ? A / 100 : A); }
            init { }
        }

        public double B
        {
            get { return (Unit == UnitOfMeasure.milimeter) ? B / 1000 : ((Unit == UnitOfMeasure.centimeter) ? B / 100 : B); }   
            init { }
        }

        public double C
        {
            get {  return (Unit == UnitOfMeasure.milimeter) ? C / 1000 : ((Unit == UnitOfMeasure.centimeter) ? C / 100 : C); }

            init { }
        }

        public UnitOfMeasure Unit { get; init; }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            A = a ?? 0.1;
            B = b ?? 0.1;
            C = c ?? 0.1;
            Unit = unit;

            A = Math.Min(Math.Truncate(A * 1000) / 1000, 100000);
            B = Math.Min(Math.Truncate(B * 1000) / 1000, 100000);
            C = Math.Min(Math.Truncate(C * 1000) / 1000, 100000);

            if (Unit == UnitOfMeasure.milimeter)
            {
                if(a.HasValue)
                    A /= 1000;
                if (b.HasValue)
                    B /= 1000;
                if (c.HasValue)
                   C /= 1000;
            }
            else if (Unit == UnitOfMeasure.centimeter)
            {
                if (a.HasValue)
                    A /= 100;
                if (b.HasValue)
                    B /= 100;
                if (c.HasValue)
                    C /= 100;
            }

            if (A < 0.001 || B < 0.001 || C < 0.001)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (A > 10 || B > 10 || C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        
    }
}
    
