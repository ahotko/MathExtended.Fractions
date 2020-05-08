using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        [Flags]
        public enum DisplayOptions
        {
            None = 0,
            ShowWholePart = 1,
            UseUnicodeFractions = 2
        }

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
        /// <param name="fraction">Fraction must be in format n/d (e.g. 3/4) or in continued fraction format (e.g. [2;1,2,1,1,4,1,1,6,1,1,8])</param>
        public Fraction(string fraction)
        {
            if (Regex.IsMatch(fraction, Constants.FractionMatchingPattern))
            {
                ParseFraction(fraction);
                return;
            }

            if (Regex.IsMatch(fraction, Constants.ContinuedFractionMatchingPattern))
            {
                ParseContinuedFraction(fraction);
                return;
            }
            throw new ArgumentException("Invalid fraction format.", "fraction");
        }

        public Fraction(double value, double accuracy = 0.00001)
        {
            Accuracy = accuracy;
            DecimalToFraction(value);
        }

        public string ToString(DisplayOptions displayOptions = DisplayOptions.None)
        {
            string result = String.Format($"{this.Numerator}/{this.Denominator}");

            if (displayOptions.HasFlag(DisplayOptions.ShowWholePart))
            {
                int signNum = Math.Sign(Numerator);
                int signDen = Math.Sign(Denominator);

                int absNum = Math.Abs(Numerator);
                int absDen = Math.Abs(Denominator);

                int wholePart = Numerator / Denominator;
                int numeratorRemainder = absNum % absDen;

                if (absDen == 1)
                {
                    result = String.Format($"{signDen * this.Numerator}");
                }
                else if (absNum == absDen)
                {
                    result = String.Format($"{signNum * signDen}");
                }
                else if (wholePart != 0 && numeratorRemainder > 0)
                {
                    result = String.Format($"{wholePart} {numeratorRemainder}/{absDen}");
                }
                else if (wholePart != 0 && numeratorRemainder == 0)
                {
                    result = String.Format($"{wholePart}");
                }
            }
            if (displayOptions.HasFlag(DisplayOptions.UseUnicodeFractions) && result.Contains("/"))
            {
                //it's a fraction, not just a whole number
                var parts = result.Split(new char[] { ' ' });

                string wholePart = (parts.Length != 2) ? String.Empty : parts[0];
                string fractionalPart = parts[(parts.Length == 2) ? 1 : 0];

                var builder = new StringBuilder();
                bool isNumerator = true;

                foreach (char number in fractionalPart)
                {
                    if (number == '/')
                    {
                        isNumerator = false;
                        builder.Append(Constants.Characters.Slash);
                    }
                    else
                    {
                        int digit = Convert.ToInt32(number) - 0x30;
                        builder.Append(isNumerator ? Constants.Characters.Superscript.Mapping[digit] : Constants.Characters.Subscript.Mapping[digit]);
                    }
                }

                result = $"{wholePart} {builder.ToString()}";
            }
            return result.Trim();
        }
    }
}
