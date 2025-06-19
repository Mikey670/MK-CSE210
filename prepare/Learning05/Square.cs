public class Square : Shape
{
    double _side;

    public double GetSide() => _side;
    public void SetSide(double side) => _side = side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}