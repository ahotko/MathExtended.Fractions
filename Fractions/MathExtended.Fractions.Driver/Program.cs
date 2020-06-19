using System;
using System.Text;

namespace MathExtended.Fractions.Driver
{
    class Program
    {
        private static ConsoleColor defaultForegroundColor = ConsoleColor.White;

        private static void SetGreenFontColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void SetDefaultFontColor()
        {
            Console.ForegroundColor = defaultForegroundColor;
        }

        public static void Title(string title)
        {
            SetGreenFontColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(title);
            SetDefaultFontColor();
            Console.WriteLine("============================================================");
        }

        private static void OutputFractionWithModifiers(Fraction fraction)
        {
            var builder = new StringBuilder();
            builder.Append("Fraction = ").Append(fraction.ToString());
            builder.Append(", ").Append("as mixed number = ").Append(fraction.ToString(Fraction.DisplayOptions.ImproperFractionAsMixedNumber));
            builder.Append(", ").Append("with Unicode characters = ").Append(fraction.ToString(Fraction.DisplayOptions.UseUnicodeCharacters));
            builder.Append(", ").Append("all modifiers = ").Append(fraction.ToString(Fraction.DisplayOptions.ImproperFractionAsMixedNumber | Fraction.DisplayOptions.UseUnicodeCharacters));
            Console.WriteLine(builder.ToString());
        }

        static void Main(string[] args)
        {
            Console.Title = "C# MathExtended.Fractions Class Library (Test)";
            //for support of unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //testing fractions
            Fraction fraction = new Fraction(2, 5);
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or only by numerator part (in this case denominator is 1):
            fraction = new Fraction(2);
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or from string in format "numerator/denominator":
            fraction = new Fraction("1/5");
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or from decimal value with accuracy:
            fraction = new Fraction(0.3333, 0.01);
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or from decimal value with default accuracy:
            fraction = new Fraction(0.3333);
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //Operations
            //Addition
            Title("Addition");
            var fractionOne = new Fraction(1, 5);
            var fractionTwo = new Fraction(2, 5);
            var result = fractionOne + fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne + 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne + 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Subtraction
            Title("Subtraction");
            result = fractionOne - fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne - 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne - 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Multiplication
            Title("Multiplication");
            result = fractionOne * fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne * 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne * 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Division
            Title("Division");
            result = fractionOne / fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne / 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne / 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //other operations
            Title("Reducing");
            fraction = new Fraction(3, 15);
            Console.WriteLine($"Fraction = {fraction.ToString()}");
            fraction.Reduce();
            Console.WriteLine($"Fraction reduced = {fraction.ToString()}");

            Title("Inversion");
            fraction = new Fraction(3, 15);
            Console.WriteLine($"Fraction = {fraction.ToString()}");
            fraction.Inverse();
            Console.WriteLine($"Fraction inversed = {fraction.ToString()}");
            fraction.Reduce();
            Console.WriteLine($"Fraction inversed and reduced = {fraction.ToString()}");

            //Assigning the value
            //...or by using numerator and denominator properties:
            Title("Assigning the value");
            fraction.Numerator = 3;
            fraction.Denominator = 7;
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or by using .AsDouble property:
            fraction.AsDouble = 0.5;
            Console.WriteLine($"Fraction = {fraction.ToString()}, AsDouble = {fraction.AsDouble}");

            //...or by using .AsFloat property:
            fraction.AsFloat = 0.5f;
            Console.WriteLine($"Fraction = {fraction.ToString()}, AsFloat = {fraction.AsFloat}");

            Title("Different outputs");
            fraction = new Fraction(10, 5);
            OutputFractionWithModifiers(fraction);
            fraction = new Fraction(11, 5);
            OutputFractionWithModifiers(fraction);
            fraction = new Fraction(3, 5);
            OutputFractionWithModifiers(fraction);
            fraction = new Fraction(15, -15);
            OutputFractionWithModifiers(fraction);
            fraction = new Fraction(11, 175);
            OutputFractionWithModifiers(fraction);
            fraction = new Fraction(113, 11);
            OutputFractionWithModifiers(fraction);

            Title("Continued fractions");
            fraction = new Fraction(ContinuedFractions.e);
            Console.WriteLine($"Fraction (e) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(ContinuedFractions.Pi);
            Console.WriteLine($"Fraction (Pi) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(Math.PI);
            Console.WriteLine($"Fraction (Math.Pi) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(ContinuedFractions.Phi);
            Console.WriteLine($"Fraction (Phi) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(ContinuedFractions.Sqrt2);
            Console.WriteLine($"Fraction (\u221A2) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(ContinuedFractions.Sqrt3);
            Console.WriteLine($"Fraction (\u221A3) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction(ContinuedFractions.SqrtOneHalf);
            Console.WriteLine($"Fraction (\u221A\u00BD) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");
            fraction = new Fraction("[2;1,4,3]");
            Console.WriteLine($"Fraction (45/16) = {fraction.ToString()}, AsDouble = {fraction.AsDouble}, AsContinuedFraction = {fraction.AsContinuedFraction}");

            Console.ReadKey();
        }
    }
}
