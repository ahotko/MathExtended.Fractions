using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        /// <summary>
        /// Display Options for fractions.
        /// </summary>
        [Flags]
        public enum DisplayOptions
        {
            /// <summary>Default display of fraction (e.g. 2/5 or 31/7)</summary>
            None = 0,
            /// <summary>Show improper fractions (e.g. 7/5) as mixed number (1 2/5)</summary>
            ImproperFractionAsMixedNumber = 1,
            /// <summary>Use unicode superscript and subscript set instead of standard ACSII set for numbers in fraction.</summary>
            UseUnicodeCharacters = 2
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
            int fractionSign = Math.Sign(Numerator) / Math.Sign(Denominator);

            int usedNum = Math.Abs(Numerator);
            int usedDen = Math.Abs(Denominator);

            string wholePart = String.Empty;
            string fractionalPart = String.Format($"{usedNum}/{usedDen}");

            if (displayOptions.HasFlag(DisplayOptions.ImproperFractionAsMixedNumber))
            {
                int absNum = usedNum;
                int absDen = usedDen;

                int integerPart = absNum / absDen;
                int numeratorRemainder = absNum % absDen;

                if (absDen == 1)
                {
                    wholePart = String.Format($"{this.Numerator}");
                    fractionalPart = String.Empty;
                }
                else if (absNum == absDen)
                {
                    wholePart = String.Format($"{absNum / absDen}");
                    fractionalPart = String.Empty;
                }
                else if (integerPart != 0 && numeratorRemainder > 0)
                {
                    wholePart = String.Format($"{integerPart}");
                    fractionalPart = $"{numeratorRemainder}/{absDen}";
                    usedNum = numeratorRemainder;
                    usedDen = absDen;
                }
                else if (integerPart != 0 && numeratorRemainder == 0)
                {
                    wholePart = String.Format($"{integerPart}");
                    fractionalPart = String.Empty;
                }
            }
            if (displayOptions.HasFlag(DisplayOptions.UseUnicodeCharacters) && !String.IsNullOrEmpty(fractionalPart))
            {
                //test, if we can use vulgar fraction
                if (Constants.Characters.VulgarFractions.ContainsKey(Tuple.Create(usedNum, usedDen)))
                {
                    fractionalPart = Constants.Characters.VulgarFractions[Tuple.Create(usedNum, usedDen)];
                }
                else
                {
                    var builder = new StringBuilder();
                    bool isNumerator = true;

                    foreach (char number in fractionalPart)
                    {
                        if (number == '/')
                        {
                            isNumerator = false;
                            builder.Append(Constants.Characters.FractionSlash);
                        }
                        else
                        {
                            int digit = Convert.ToInt32(number) - 0x30;
                            builder.Append(isNumerator ? Constants.Characters.Superscript.Mapping[digit] : Constants.Characters.Subscript.Mapping[digit]);
                        }
                    }

                    fractionalPart = $"{builder.ToString()}";
                }
            }

            string extraWhiteSpace = String.IsNullOrEmpty(wholePart) ? String.Empty : " ";
            string sign = (fractionSign > 0) ? String.Empty : "-";
            return $"{sign}{wholePart}{extraWhiteSpace}{fractionalPart}".Trim();
        }
    }
}
