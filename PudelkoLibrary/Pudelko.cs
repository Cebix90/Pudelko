
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

       
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            _a = a ?? 0.1;
            _b = b ?? 0.1;
            _c = c ?? 0.1;
            Unit = unit;

            
            if (Unit == UnitOfMeasure.milimeter)
            {
                if (a.HasValue)
                    _a /= 1000;
                if (b.HasValue)
                    _b /= 1000;
                if (c.HasValue)
                    _c /= 1000;
            }
            else if (Unit == UnitOfMeasure.centimeter)
            {
                if (a.HasValue)
                    _a /= 100;
                if (b.HasValue)
                    _b /= 100;
                if (c.HasValue)
                    _c /= 100;
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
    
