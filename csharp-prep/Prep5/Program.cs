using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static float PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return float.Parse(Console.ReadLine());
    }

    static float SquareNumber(float number)
    {
        return number * number;
    }

    static void DisplayResult(string name, float number)
    {
        Console.WriteLine($"{name}, the square of your number is {SquareNumber(number)}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        float favoriteNumber = PromptUserNumber();
        DisplayResult(userName, favoriteNumber);
    }
}