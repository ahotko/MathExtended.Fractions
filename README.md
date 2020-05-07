# MathExtended.Fractions
Pure C# Fractions Library.

## Legal information and credits

ImageProcessing is project by Ales Hotko and was first released in May 2020. It's licensed under the MIT license.

## Usage

### Creation

```csharp
//fraction can be created with numerator and denominator as parameters:
Fraction fraction = new Fraction(2, 5);
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 2/5

//...or only by numerator part (in this case denominator is 1):
Fraction fraction = new Fraction(2);
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 2/1

//...or from string in format "numerator/denominator":
Fraction fraction = new Fraction("1/5");
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 1/5

//...or from decimal value with accuracy:
Fraction fraction = new Fraction(0.3333, 0.01);
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 1/3

//...or from decimal value with default accuracy:
Fraction fraction = new Fraction(0.3333);
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 3333/10000
```

### Assigning the value

```csharp
//value can be assigned at creation, as seen in [previous section](### Creation)

//...or by using numerator and denominator properties:
fraction.Numerator = 3;
fraction.Denominator = 7;
Console.WriteLine($"Fraction = {fraction.ToString()}");
//Output:
//Fraction = 3/7

//...or by using .AsDouble property:
fraction.AsDouble = 0.5;
Console.WriteLine($"Fraction = {fraction.ToString()}, AsDouble = {fraction.AsDouble}");
//Output:
//Fraction = 1/2, AsDouble = 0.5

//...or by using .AsFloat property:
fraction.AsFloat = 0.5f;
Console.WriteLine($"Fraction = {fraction.ToString()}, AsFloat = {fraction.AsFloat}");
//Output:
//Fraction = 1/2, AsFloat = 0.5
```

### Available Mathematical Operations

#### Addition

```csharp
//addition of two fractions
var fractionOne = new Fraction(1, 5);
var fractionTwo = new Fraction(2, 5);
var result = fractionOne + fractionTwo;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 15/25, reduced fraction = 3/5

//addition of fraction and number
result = fractionOne + 3;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 16/5, reduced fraction = 16/5

//addition of fraction and a decimal number
result = fractionOne + 0.5;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 7/10, reduced fraction = 7/10
```

#### Subtraction

```csharp
//subtraction of two fractions
var fractionOne = new Fraction(1, 5);
var fractionTwo = new Fraction(2, 5);
var result = fractionOne - fractionTwo;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = -1/5, reduced fraction = -1/5

//subtraction of fraction and number
result = fractionOne - 3;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = -14/5, reduced fraction = -14/5

//subtraction of fraction and a decimal number
result = fractionOne - 0.5;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = -3/10, reduced fraction = -3/10
```

#### Multiplication

```csharp
//multiplication of two fractions
var fractionOne = new Fraction(1, 5);
var fractionTwo = new Fraction(2, 5);
var result = fractionOne * fractionTwo;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 2/25, reduced fraction = 2/25

//multiplication of fraction and number
result = fractionOne * 3;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 3/5, reduced fraction = 3/5

//multiplication of fraction and a decimal number
result = fractionOne * 0.5;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 1/10, reduced fraction = 1/10
```

#### Division

```csharp
//division of two fractions
var fractionOne = new Fraction(1, 5);
var fractionTwo = new Fraction(2, 5);
var result = fractionOne / fractionTwo;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 5/10, reduced fraction = 1/2

//division of fraction and number
result = fractionOne / 3;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 1/15, reduced fraction = 1/15

//division of fraction and a decimal number
result = fractionOne / 0.5;
Console.WriteLine($"Fraction = {result.ToString()}, reduced fraction = {result.Reduced().ToString()}");
//Output:
//Fraction = 2/5, reduced fraction = 2/5
```

### Other operations

#### Reduce

```csharp
var fraction = new Fraction(3, 15);
Console.WriteLine($"Fraction = {fraction.ToString()}");
fraction.Reduce();
Console.WriteLine($"Fraction reduced = {fraction.ToString()}");
//Output:
//Fraction = 3/15
//Fraction reduced = 1/5
```

#### Inverse

```csharp
fraction = new Fraction(3, 15);
Console.WriteLine($"Fraction = {fraction.ToString()}");
fraction.Inverse();
Console.WriteLine($"Fraction inversed = {fraction.ToString()}");
fraction.Reduce();
Console.WriteLine($"Fraction inversed and reduced = {fraction.ToString()}");
//Output:
//Fraction = 3/15
//Fraction inversed = 15/3
//Fraction inversed and reduced = 5/1
```