using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 1;


        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());



            numbers.Add(number);
        }


        int total = 0;
        int max = int.MinValue;
        int min = int.MaxValue;

        foreach(int i in numbers)
        {
            total += i;

            if (i > max) max = i;
            if (i < min && i > 0) min = i;
        }

        float avg = ((float)total) / numbers.Count;
        numbers.Sort();

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
        Console.WriteLine("The sorted list is:");
        foreach (int i in numbers)
        {
            Console.WriteLine($"{i}");
        }
    }
}