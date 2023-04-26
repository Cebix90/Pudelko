﻿using System.Globalization;

namespace PudelkoLibrary
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
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

        public double Volume { get { return Math.Round(A * B * C, 9); } }
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

        #region Equals
        public bool Equals(Pudelko? other)
        {
            if (this is null && other is null) return true;
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Volume == other.Volume && this.Field == other.Field;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Pudelko) return false;

            return Equals(obj as Pudelko);
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C);

        public static bool operator ==(Pudelko left, Pudelko right)
        {
            if (left is null && right is null) return true;
            if (left is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(Pudelko left, Pudelko right) => !(left == right);
        #endregion

        #region Override + operator
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double p1Max = Math.Max(Math.Max(p1.A, p1.B), p1.C);
            double p1Min = Math.Min(Math.Min(p1.A, p1.B), p1.C);
            double p1Mid = p1.A + p1.B + p1.C - p1Max - p1Min;

            double p2Max = Math.Max(Math.Max(p2.A, p2.B), p2.C);
            double p2Min = Math.Min(Math.Min(p2.A, p2.B), p2.C);
            double p2Mid = p2.A + p2.B + p2.C - p2Max - p2Min;

            if (p1Max + p2Max <= 10)
            {
                double p3Min = Math.Max(p1Min, p2Min);
                double p3Mid = Math.Max(p1Mid, p2Mid);
                double p3Max = p1Max + p2Max;

                return new Pudelko(p3Max, p3Mid, p3Min);
            }
            else if (p1Mid + p2Mid <= 10)
            {
                double p3Max = Math.Max(p1Max, p1Max);
                double p3Min = Math.Max(p1Min, p2Min);
                double p3Mid = p1Mid + p2Mid;

                return new Pudelko(p3Max, p3Mid, p3Min);
            }
            else
            {
                double p3Max = Math.Max(p1Max, p2Max);
                double p3Mid = Math.Max(p1Mid, p2Mid);
                double p3Min = p1Min + p2Min;

                return new Pudelko(p3Max, p3Mid, p3Min);
            }
        }
        #endregion

        #region Conversion
        public static explicit operator double[](Pudelko p)
        {
            return new double[] { p.A, p.B, p.C };
        }

        public static implicit operator Pudelko(ValueTuple<int,int,int> dimensions)
        {
            return new Pudelko(dimensions.Item1, dimensions.Item2, dimensions.Item3, UnitOfMeasure.milimeter);
        }
        #endregion
    }
}

