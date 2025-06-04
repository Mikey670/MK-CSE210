class Program
{
    static void Main()
    {
        MathAssignment a1 = new MathAssignment("Monsiuer pete", "Trigonomitry", "5.6", "40-67");
        WritingAssignment a2 = new WritingAssignment("David Bagmar", "Advanced Writing", "Why Simicolons are Evil");

        Console.WriteLine(a1.GetSummary());
        Console.WriteLine(a1.GetHomeworkList());
        Console.WriteLine();
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetWritingInformation());
    }
}