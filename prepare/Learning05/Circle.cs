public class Circle : Shape
{
    double _radius;

    public void SetRadius(double radius) => _radius = radius;
    public double GetRadius() => _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return double.Pi * (_radius * _radius);
    }
}