using System.Dynamic;

public class Cell
{
    protected string _type = "n";
    public string GetStringType() => _type;

    public virtual void DisplayCell()
    {
        Console.Write(" ");
    }

    public virtual void SetHintIndexH(int index) {}
    public virtual void SetHintIndexV(int index) {}
    public virtual void SetStringType(string type) {}
    public virtual string GetContent() => " ";

    public virtual int[] GetHintIndex()
    {
        return [-1, -1];
    }
}