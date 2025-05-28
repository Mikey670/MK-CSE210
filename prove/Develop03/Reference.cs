using System.ComponentModel.DataAnnotations;

public class Reference
{
    //Private variables
    string _book = "";
    int _chapter = 0;
    int _startVerse = 0;
    int _endVerse = 0;

    //Public constructors
    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    //Public Methods
    public void Display()
    {
        string verses;

        if (_endVerse != _startVerse)
        {
            verses = $"{_startVerse}-{_endVerse}";
        }
        else
        {
            verses = $"{_startVerse}";
        }

        string output = $"{_book} {_chapter}:{verses}";

        Console.WriteLine(output);
    }
}