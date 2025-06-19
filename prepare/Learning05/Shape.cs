public abstract class Shape
{
    string _color = "";

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor() => _color;
    public void SetColor(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
}