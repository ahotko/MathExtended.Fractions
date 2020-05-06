namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() : this(1, 1) { }

        public Fraction(int numerator) : this(numerator, 1) { }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(double value)
        {
            DecimalToFraction(value);
        }
    }
}
