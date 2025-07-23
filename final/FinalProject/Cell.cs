
public class Cell(string content, bool horizontal, string hint)
{
    private string _content = content;
    private bool _horizontal = horizontal;
    private string _hint = hint;
    private string _alternateHint = null;
    private int _x;
    private int _y;

    public string GetContent() => _content;
    public void SetContent(string content) => _content = content;
    public bool GetHorizontal() => _horizontal;
    public string GetHint() => _hint;
    public string GetAlternateHint() => _alternateHint;
    public void SetAlternateHint(string hint) => _alternateHint = hint;

    public void SetCoordinates(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public int GetX() => _x;
    public int GetY() => _y;

    public void PrintHints()
    {
        if (_horizontal)
        {
            Console.WriteLine("Across:");
            Console.WriteLine($"    {_hint}");

            if (_alternateHint != null)
            {
                Console.WriteLine("Down:");
                Console.WriteLine($"    {_alternateHint}");
            }
        }
        else
        {
            if (_alternateHint != null)
            {
                Console.WriteLine("Across:");
                Console.WriteLine($"    {_alternateHint}");
            }
            Console.WriteLine("Down:");
            Console.WriteLine($"    {_hint}");
        }
    }
}