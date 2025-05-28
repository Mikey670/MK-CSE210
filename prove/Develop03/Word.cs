public class Word
{
    //private variables
    bool _isHidden = false;
    string _text;

    //public constructors
    public Word(string text)
    {
        _text = text;
    }

    //public methods
    public void Display()
    {
        if (!_isHidden)
        {
            Console.Write($"{_text} ");
            return;
        }


        string output = "";
        for (int i = 0; i < _text.Length; i++)
        {
            output += "X";
        }
        Console.Write($"{output} ");
    }

    public bool CheckHidden()
    {
        return _isHidden;
    }

    public void SetHidden(bool hidden)
    {
        _isHidden = hidden;
    }
}