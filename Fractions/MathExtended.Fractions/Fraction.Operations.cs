namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        public int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0) return 1;
            int tmp = 0;
            while(a % b > 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }
            return b;
        }

        public void Reduce()
        {
            int num = ((Numerator > 0) ? 1 : -1) * Numerator;
            int den = ((Denominator > 0) ? 1 : -1) * Denominator;
            int gcd = GreatestCommonDivisor(num, den);
            if (gcd > 0)
            {
                Numerator /= gcd;
                Denominator /= gcd;
            }
        }

        public void Inverse()
        {
            int tmp = Numerator;
            Numerator = Denominator;
            Denominator = tmp;
        }

        public Fraction Reduced()
        {
            var result = new Fraction(Numerator, Denominator);
            result.Reduce();
            return result;
        }

        public Fraction Inversed()
        {
            return new Fraction(Denominator, Numerator);
        }
    }
}
