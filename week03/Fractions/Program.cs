using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(90, 80);

        Console.WriteLine($"Previous numerator: {f1.GetNumerator()}");
        Console.WriteLine($"Forms: {f1.GetFractionString()} {f1.GetDecimalValue()}");
        f1.SetNumerator(23);
        Console.WriteLine($"New numerator: {f1.GetNumerator()}");
        Console.WriteLine($"Previous denominator: {f1.GetDenominator()}");
        Console.WriteLine($"Forms: {f1.GetFractionString()} {f1.GetDecimalValue()}");
        f1.SetDenominator(67);
        Console.WriteLine($"New denominator: {f1.GetDenominator()}");
        Console.WriteLine($"Forms: {f1.GetFractionString()} {f1.GetDecimalValue()}");
    }
}