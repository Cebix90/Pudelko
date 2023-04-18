
namespace PudelkoLibrary
{
    public sealed class Pudelko
    {
        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }
        public UnitOfMeasure Unit { get; init; }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            A = a ?? 0.1;
            B = b ?? 0.1;
            C = c ?? 0.1;
            Unit = unit;

            // odcinamy cyfry poza zakresem dla określonej jednostki
            A = Math.Min(Math.Truncate(A * 1000) / 1000, 100000);
            B = Math.Min(Math.Truncate(B * 1000) / 1000, 100000);
            C = Math.Min(Math.Truncate(C * 1000) / 1000, 100000);

            // zamieniamy wartości na metry
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

            // sprawdzamy ograniczenia wymiarów
            if (A < 0.001 || B < 0.001 || C < 0.001)
            {
                throw new ArgumentOutOfRangeException("Wymiary pudełka muszą być dodatnie!");
            }
            if (A > 10 || B > 10 || C > 10)
            {
                throw new ArgumentOutOfRangeException("Wymiary pudełka nie mogą przekroczyć 10 m!");
            }
        }
    }
}
    
