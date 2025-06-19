public class Rectangle : Shape
{
    double _length;
    double _width;

    public void SetLength(double length) => _length = length;
    public void SetWidth(double width) => _width = width;
    public double GetLength() => _length;
    public double GetWidth() => _width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}