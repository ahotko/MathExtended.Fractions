using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathExtended.Fractions.Test
{
    [TestClass]
    public class Fractions
    {
        [TestMethod]
        public void Creation()
        {
            var fractionFromDecimal = new Fraction(0.75);
            var fractionFromDecimal_1_over_3 = new Fraction(0.333333);
            var fractionFromDecimal_1_over_10 = new Fraction(0.1);
            var fractionFromString = new Fraction("1/5");
            var fractionFromSeparateValues = new Fraction(2, 5);

            Assert.IsTrue(fractionFromDecimal == new Fraction(3, 4), "Fraction from decimal is not ok!");
            Assert.IsTrue(fractionFromDecimal_1_over_3 == new Fraction(1, 3), "Fraction 1/3 from decimal is not ok!");
            Assert.IsTrue(fractionFromDecimal_1_over_10 == new Fraction(1, 10), "Fraction 1/10 from decimal is not ok!");
            Assert.IsTrue(fractionFromString == new Fraction(1, 5), "Fraction from string is not ok!");
            Assert.IsTrue(fractionFromSeparateValues == new Fraction(2, 5), "Fraction from separate values is not ok!");
        }

        [TestMethod]
        public void Addition()
        {
            var a = new Fraction(1, 3);
            var b = new Fraction(1, 3);
            var c = a + b;
            c.Reduce();
            Assert.IsTrue(c.Numerator == 2 && c.Denominator == 3, "Addition between fractions is not ok!");
            //
            c = a + 1;
            Assert.IsTrue(c.Numerator == 4 && c.Denominator == 3, "Addition between fraction and number is not ok!");
            //
            c = 1 + a;
            Assert.IsTrue(c.Numerator == 4 && c.Denominator == 3, "Addition between fraction and number is not ok!");
        }

        [TestMethod]
        public void Subtraction()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);
            var c = a - b;
            c.Reduce();
            Assert.IsTrue(c.Numerator == 1 && c.Denominator == 3, "Subtraction between fractions is not ok!");
            //
            c = a - 1;
            Assert.IsTrue(c.Numerator == -1 && c.Denominator == 3, "Subtraction between fraction and number is not ok!");
            //
            c = 1 - a;
            Assert.IsTrue(c.Numerator == 1 && c.Denominator == 3, "Subtraction between fraction and number is not ok!");
        }

        [TestMethod]
        public void Multiplication()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(5, 3);
            var c = a * b;
            c.Reduce();
            Assert.IsTrue(c.Numerator == 10 && c.Denominator == 9, "Multiplication between fractions is not ok!");
            //
            c = a * 2;
            Assert.IsTrue(c.Numerator == 4 && c.Denominator == 3, "Multiplication between fraction and number is not ok!");
            //
            c = 3 * a;
            c.Reduce();
            Assert.IsTrue(c.Numerator == 2 && c.Denominator == 1, "Multiplication between fraction and number is not ok!");
        }
    }
}
