using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Fractions.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("Addition");
            var fractionOne = new Fraction(1, 5);
            var fractionTwo = new Fraction(2, 5);
            var result = fractionOne + fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne + 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne + 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Subtraction
            Console.WriteLine();
            Console.WriteLine("Subtraction");
            result = fractionOne - fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne - 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne - 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Multiplication
            Console.WriteLine();
            Console.WriteLine("Multiplication");
            result = fractionOne * fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne * 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne * 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //Division
            Console.WriteLine();
            Console.WriteLine("Division");
            result = fractionOne / fractionTwo;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne / 3;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            result = fractionOne / 0.5;
            Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");

            //other operations
            Console.WriteLine();
            Console.WriteLine("Reducing");
            fraction = new Fraction(3, 15);
            Console.WriteLine($"Fraction = {fraction.ToString()}");
            fraction.Reduce();
            Console.WriteLine($"Fraction reduced = {fraction.ToString()}");

            Console.WriteLine();
            Console.WriteLine("Inversion");
            fraction = new Fraction(3, 15);
            Console.WriteLine($"Fraction = {fraction.ToString()}");
            fraction.Inverse();
            Console.WriteLine($"Fraction inversed = {fraction.ToString()}");
            fraction.Reduce();
            Console.WriteLine($"Fraction inversed and reduced = {fraction.ToString()}");

            //Assigning the value
            //...or by using numerator and denominator properties:
            Console.WriteLine();
            Console.WriteLine("Assigning the value");
            fraction.Numerator = 3;
            fraction.Denominator = 7;
            Console.WriteLine($"Fraction = {fraction.ToString()}");

            //...or by using .AsDouble property:
            fraction.AsDouble = 0.5;
            Console.WriteLine($"Fraction = {fraction.ToString()}, AsDouble = {fraction.AsDouble}");

            //...or by using .AsFloat property:
            fraction.AsFloat = 0.5f;
            Console.WriteLine($"Fraction = {fraction.ToString()}, AsFloat = {fraction.AsFloat}");

            Console.WriteLine();
            Console.WriteLine("Different outputs");
            fraction = new Fraction(10, 5);
            Console.WriteLine($"Fraction = {fraction.ToString()}, with whole part = {fraction.ToString(true)}");
            fraction = new Fraction(11, 5);
            Console.WriteLine($"Fraction = {fraction.ToString()}, with whole part = {fraction.ToString(true)}");
            fraction = new Fraction(3, 5);
            Console.WriteLine($"Fraction = {fraction.ToString()}, with whole part = {fraction.ToString(true)}");
            fraction = new Fraction(15, -15);
            Console.WriteLine($"Fraction = {fraction.ToString()}, with whole part = {fraction.ToString(true)}");

            Console.ReadKey();
        }
    }
}
