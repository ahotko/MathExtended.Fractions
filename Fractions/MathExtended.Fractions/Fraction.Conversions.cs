using System;
using System.Collections.ObjectModel;
using System.Text;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        public double Accuracy { get; set; } = 0.00001;

        /// <summary>
        /// Converts decimal number (double) to fraction.
        /// Algorithm: "Algorithm To Convert A Decimal To A Fraction" by John Kennedy, Mathematics Department, Santa Monica College, 1900 Pico Blvd., Santa Monica, CA 90405, jrkennedy6@gmail.com
        /// </summary>
        /// <param name="value"></param>
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
                Numerator = sign * Int32.MaxValue;
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

        private string GenerateContinuedFraction()
        {
            int a0 = Numerator / Denominator;
            int remainder = Numerator % Denominator;
            int elementCount = 0;
            Collection<int> sequence = new Collection<int>();

            int midResult = Denominator;

            while (remainder != 0 && elementCount < Constants.ContinuedMaxElements)
            {
                int prevRemainder = remainder;
                int element = midResult / remainder;
                remainder = midResult % remainder;
                midResult = prevRemainder;
                sequence.Add(element);
                elementCount++;
            }
            var builder = new StringBuilder();
            builder.Append("[").Append(a0).Append(";").Append(string.Join(",", sequence)).Append("]");
            return builder.ToString();
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

        public string AsContinuedFraction
        {
            get => GenerateContinuedFraction();
            set
            {
                ParseContinuedFraction(value);
            }
        }
    }
}
