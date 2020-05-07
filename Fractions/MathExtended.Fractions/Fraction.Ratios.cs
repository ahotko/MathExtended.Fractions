using System;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        #region Static methods
        public static bool IsRatio(double firstValue, double secondValue, double ratio, double epsilon = 0.0001)
        {
            return IsRatio(firstValue / secondValue, ratio, epsilon);
        }

        public static bool IsRatio(double value, double ratio, double epsilon = 0.0001)
        {
            return new Fraction(value).IsRatio(ratio, epsilon);
        }

        public static double RatioError(double firstValue, double secondValue, double ratio)
        {
            return RatioError(firstValue / secondValue, ratio);
        }

        public static double RatioError(double value, double ratio)
        {
            return new Fraction(value).RatioError(ratio);
        }
        #endregion

        public bool IsRatio(double ratio, double epsilon = 0.0001)
        {
            return Math.Abs(AsDouble - ratio) < epsilon;
        }

        public double RatioError(double ratio)
        {
            return (AsDouble - ratio) / ratio;
        }
    }
}
