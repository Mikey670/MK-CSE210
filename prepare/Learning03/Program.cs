using System;

class Program
{
    private static void PrintFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        PrintFraction(fraction);
        fraction = new Fraction(1);
        PrintFraction(fraction);
        fraction = new Fraction(5);
        PrintFraction(fraction);
        fraction = new Fraction(3, 4);
        PrintFraction(fraction);
        fraction = new Fraction(1, 3);
        PrintFraction(fraction);
    }
}