using System.Globalization;

namespace PudelkoLibrary
{
    public sealed class Pudelko : IFormattable
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
            get { return _c; }

            init { _c = value; }
        }

        private UnitOfMeasure _unit;
        public UnitOfMeasure Unit { get { return _unit; } init { _unit = value; } }

        public double Volume {  get { return Math.Round(A * B * C, 9); } }
        public double Field { get { return Math.Round(2 * (A * B + B * C + A * C), 6); } }


        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            _a = a ?? 0.1;
            _b = b ?? 0.1;
            _c = c ?? 0.1;
            _unit = unit;


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
        public override string ToString()
        {
            return ToString("m");
        }

        public string ToString(string format, IFormatProvider? formatProvider = null)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            if (format == null || format == "m")
                return $"{A.ToString("F3", culture)} m × {B.ToString("F3", culture)} m × {C.ToString("F3", culture)} m";
            else if (format == "cm")
                return $"{(A * 100).ToString("F1", culture)} cm × {(B * 100).ToString("F1", culture)} cm × {(C * 100).ToString("F1", culture)} cm";
            else if (format == "mm")
                return $"{(A * 1000).ToString("F0", culture)} mm × {(B * 1000).ToString("F0", culture)} mm × {(C * 1000).ToString("F0", culture)} mm";
            else
                throw new FormatException();
        }
        #endregion

        #region BoxVolume method
        public double FieldBox() 
        { 
            return Math.Round(2*(A * B + B * C + A * C), 6);
        }
        #endregion
    }
}

