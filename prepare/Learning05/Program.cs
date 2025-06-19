using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>() { new Square("Red", 5), new Rectangle("Green", 7, 5), new Circle("Blue", 5) };

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()} Area: {s.GetArea()}");
        }
    }
}