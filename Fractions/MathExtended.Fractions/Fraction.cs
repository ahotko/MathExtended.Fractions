using System;
using System.Text.RegularExpressions;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        private int _denominator;

        public int Numerator { get; set; }
        public int Denominator
        {
            get => _denominator;
            set
            {
                if (value == 0) throw new InvalidOperationException("Denominator cannot be 0.");
                _denominator = value;
            }
        }

        public Fraction() : this(0, 1) { }

        public Fraction(int numerator) : this(numerator, 1) { }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Create fraction from string
        /// </summary>
        /// <param name="fraction">Fraction must be in format n/d (e.g. 3/4)</param>
        public Fraction(string fraction)
        {
            Regex pattern = new Regex(@"^(?<numerator>\d+)\/(?<denominator>\d+)$");
            Match match = pattern.Match(fraction);
            if (match.Success)
            {
                Numerator   = Convert.ToInt32(match.Groups["numerator"].Value.Trim());
                Denominator = Convert.ToInt32(match.Groups["denominator"].Value.Trim());
            }
        }

        public Fraction(double value, double accuracy = 0.00001)
        {
            Accuracy = accuracy;
            DecimalToFraction(value);
        }
    }
}
