using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What % Grade did you get? ");
        int grade = int.Parse(Console.ReadLine());

        //Find Base letter grade based off grade range
        string letterGrade;
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        //Decide wether to use "a" or "an" before the letter grade announcement
        string a = "a";
        if (letterGrade == "A" || letterGrade == "F") { a = "an"; }

        //Use Modulo operator to find the value of the right-most digit
        int rightmostDigit = grade % 10;

        //Decide wether to add "+" or "-" to grade
        if (rightmostDigit >= 7 && letterGrade != "A" && letterGrade != "F")
        {
            letterGrade += "+";
        }
        else if (rightmostDigit < 3 && letterGrade != "F" && grade < 100)
        {
            letterGrade += "-";
        }

        Console.WriteLine($"Your {grade}% score is {a} {letterGrade}");
    }
}