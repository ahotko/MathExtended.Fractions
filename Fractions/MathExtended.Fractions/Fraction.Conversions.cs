using System;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        public double Accuracy { get; set; } = 0.00001;

        private void DecimalToFraction(double value)
        {
            int sign = Math.Sign(value);
            value = Math.Abs(value);

            //handle exact integer parts
            if (Convert.ToInt32(value) == value)
            {
                Numerator = Convert.ToInt32(value);
                Denominator = 1;
                return;
            }
            if (value < 1E-19)
            {
                Numerator = 1;
                Denominator = Int32.MaxValue;
                return;
            }
            if (value > 1E19)
            {
                Numerator = Int32.MaxValue;
                Denominator = 1;
                return;
            }
            double valueTemp = value;
            int numerator = 0;
            int denominator = 1;
            int prevDenominator = 0;
            bool exitCondition;
            do
            {
                valueTemp = 1.0 / (valueTemp - (int)valueTemp);
                int denominatorTemp = denominator;
                denominator = denominator * (int)valueTemp + prevDenominator;
                prevDenominator = denominatorTemp;
                numerator = (int)(value * denominator + 0.5);

                exitCondition = Math.Abs(value - 1.0 * numerator / denominator) < Accuracy;
                exitCondition |= (int)valueTemp == valueTemp;
            } while (!exitCondition);

            Numerator = sign * numerator;
            Denominator = denominator;
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
