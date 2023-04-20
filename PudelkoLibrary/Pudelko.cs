
namespace PudelkoLibrary
{
    public sealed class Pudelko
    {
        #region Constructor
        private double _a;
        private double _b;
        private double _c;
        public double A
        {
            get { return _a; }
            init { _a = value; }
        }

        public double B
        {
            get { return _b; }
            init { _b = value; }
        }

        public double C
        {
            get {  return _c; }

            init { _c = value; }
        }

        public UnitOfMeasure Unit { get; init; }

        /*public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
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
        }*/
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            _a = a ?? 0.1;
            _b = b ?? 0.1;
            _c = c ?? 0.1;
            Unit = unit;

            
            if (Unit == UnitOfMeasure.milimeter)
            {
                if (a.HasValue)
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

            _a = Math.Min(Math.Truncate(_a * 1000) / 1000, 100000);
            _b = Math.Min(Math.Truncate(_b * 1000) / 1000, 100000);
            _c = Math.Min(Math.Truncate(_c * 1000) / 1000, 100000);

            if (_a < 0.001 || _b < 0.001 || _c < 0.001 || _a > 10 || _b > 10 || _c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region ToString method
        /* public override string ToString(double a, double b, double c, )
         {
             return base.ToString();
         }*/
        #endregion
    }
}
    
