using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);

        Console.WriteLine($"{fraction1.GetNumerator()}/{fraction1.GetDenominator()}");
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine($"{fraction2.GetNumerator()}/{fraction2.GetDenominator()}");
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine($"{fraction3.GetNumerator()}/{fraction3.GetDenominator()}");
        Console.WriteLine(fraction3.GetDecimalValue());
        fraction1.SetDenominator(3);
        Console.WriteLine($"{fraction1.GetNumerator()}/{fraction1.GetDenominator()}");
        Console.WriteLine(fraction1.GetDecimalValue());
    }
}