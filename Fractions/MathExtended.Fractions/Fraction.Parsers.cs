using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        private void ParseFraction(string fraction)
        {
            Regex pattern = new Regex(Constants.FractionGroupingPattern);

            Match match = pattern.Match(fraction);
            if (match.Success)
            {
                Numerator = Convert.ToInt32(match.Groups["numerator"].Value.Trim());
                Denominator = Convert.ToInt32(match.Groups["denominator"].Value.Trim());
            }
        }

        private void ParseContinuedFraction(string fraction)
        {
            Regex pattern = new Regex(Constants.ContinuedFractionGroupingPattern);
            Match match = pattern.Match(fraction);
 
            if (match.Success)
            {
                int a0 = Convert.ToInt32(match.Groups["leading"].Value.Trim());
                Collection<double> sequence = new Collection<double>();

                foreach (Capture matchedCapture in match.Groups[2].Captures)
                {
                    sequence.Insert(0, Convert.ToInt32(matchedCapture.Value));
                }
                sequence.Add(a0);

                double result = sequence[0];
                sequence.RemoveAt(0);
                foreach(double value in sequence)
                {
                    result = 1.0 / result;
                    result += value;
                }

                var continuedFraction = new Fraction(result);

                Numerator = continuedFraction.Numerator;
                Denominator = continuedFraction.Denominator;
            }
        }
    }
}
