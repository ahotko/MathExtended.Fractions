using System;

namespace MathExtended.Fractions
{
    public partial class Fraction
    {
        #region Operator +
        public static Fraction operator +(Fraction fraction) => fraction;

        public static Fraction operator +(Fraction firstValue, Fraction secondValue)
        {
            var result = new Fraction();
            result.Numerator = firstValue.Numerator * secondValue.Denominator + secondValue.Numerator * firstValue.Denominator;
            result.Denominator = firstValue.Denominator * secondValue.Denominator;
            return result;
        }

        public static Fraction operator +(Fraction firstValue, int number)
        {
            var secondValue = new Fraction(number);
            return firstValue + secondValue;
        }

        public static Fraction operator +(int number, Fraction fraction)
        {
            var firstValue = new Fraction(number);
            return firstValue + fraction;
        }
        #endregion

        #region Operator -
        public static Fraction operator -(Fraction fraction) => new Fraction(-fraction.Numerator, fraction.Denominator);

        public static Fraction operator -(Fraction firstValue, Fraction secondValue)
        {
            return firstValue + (-secondValue);
        }

        public static Fraction operator -(Fraction firstValue, int number)
        {
            return firstValue - new Fraction(number);
        }

        public static Fraction operator -(int number, Fraction fraction)
        {
            return new Fraction(number) - fraction;
        }
        #endregion

        #region Operator *
        public static Fraction operator *(Fraction firstValue, Fraction secondValue)
        {
            var result = new Fraction();
            result.Numerator = firstValue.Numerator * secondValue.Numerator;
            result.Denominator = firstValue.Denominator * secondValue.Denominator;
            return result;
        }

        public static Fraction operator *(Fraction firstValue, int number)
        {
            return firstValue * new Fraction(number);
        }

        public static Fraction operator *(int number, Fraction firstValue)
        {
            return firstValue * new Fraction(number);
        }
        #endregion

        #region Operator /
        public static Fraction operator /(Fraction firstValue, Fraction secondValue)
        {
            return firstValue * secondValue.Inversed();
        }

        public static Fraction operator /(Fraction fraction, int number)
        {
            return fraction * new Fraction(1, number);
        }

        public static Fraction operator /(int number, Fraction fraction)
        {
            return fraction * new Fraction(1, number);
        }
        #endregion

        #region Equality
        public static Boolean operator ==(Fraction firstValue, Fraction secondValue)
        {
            return (firstValue.Reduced().Numerator == secondValue.Reduced().Numerator && firstValue.Reduced().Denominator == secondValue.Reduced().Denominator);
        }

        public static Boolean operator !=(Fraction firstValue, Fraction secondValue)
        {
            return !(firstValue == secondValue);
        }
        #endregion

        #region Operator >
        public static Boolean operator >(Fraction firstValue, Fraction secondValue)
        {
            return (firstValue.AsDouble > secondValue.AsDouble);
        }

        public static Boolean operator >(Fraction firstValue, double secondValue)
        {
            return (firstValue.AsDouble > secondValue);
        }

        public static Boolean operator >(double firstValue, Fraction secondValue)
        {
            return (firstValue > secondValue.AsDouble);
        }
        #endregion

        #region Operator <
        public static Boolean operator <(Fraction firstValue, Fraction secondValue)
        {
            return (firstValue.AsDouble < secondValue.AsDouble);
        }

        public static Boolean operator <(Fraction firstValue, double secondValue)
        {
            return (firstValue.AsDouble < secondValue);
        }

        public static Boolean operator <(double firstValue, Fraction secondValue)
        {
            return (firstValue < secondValue.AsDouble);
        }
        #endregion

        #region Operator >=
        public static Boolean operator >=(Fraction firstValue, Fraction secondValue)
        {
            return (firstValue.AsDouble >= secondValue.AsDouble);
        }
        #endregion

        #region Operator <=
        public static Boolean operator <=(Fraction firstValue, Fraction secondValue)
        {
            return (firstValue.Reduced().Numerator == secondValue.Reduced().Numerator && firstValue.Reduced().Denominator == secondValue.Reduced().Denominator);
        }
        #endregion

        public override bool Equals(object obj)
        {
            var value = obj as Fraction;
            if (obj == null)
            {
                return false;
            }
            return (this == value);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return String.Format($"{this.Numerator}/{this.Denominator}");
        }
    }
}
