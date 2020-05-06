namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        public double Accuracy { get; set; } = 0.00001;

        private void DecimalToFraction(double value)
        {

        }

        public double AsDouble
        {
            get => 1.0 * Numerator / Denominator;
            set
            {
                DecimalToFraction(value);
            }
        }

        public float AsFloat
        {
            get => 1.0f * Numerator / Denominator;
            set
            {
                DecimalToFraction(value);
            }
        }
    }
}
