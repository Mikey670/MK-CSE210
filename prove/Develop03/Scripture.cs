public class Scripture
{
    //private variables
    Random rng = new Random();
    List<Word> _words = new List<Word>();
    Reference _reference;
    int _wordCount = 0;
    int _hiddenWordCount = 0;
    bool _isHidden = false;

    //public constructors
    public Scripture(string text, string book, int chapter, int startVerse)
    {
        _reference = new Reference(book, chapter, startVerse);

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);

            _wordCount++;
        }
    }

    public Scripture(string text, string book, int chapter, int startVerse, int endVerse)
    {
        _reference = new Reference(book, chapter, startVerse, endVerse);

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);

            _wordCount++;
        }
    }

    //public methods
    public void Display()
    {
        _reference.Display();
        foreach (Word word in _words)
        {
            word.Display();
        }
        Console.WriteLine("");
    }

    public void HideWords(int wordsToHide)
    {
        int hiddenWords = 0;

        while (hiddenWords < wordsToHide)
        {
            if (!_isHidden)
            {
                int index = rng.Next(_words.Count);

                if (!_words[index].CheckHidden())
                {
                    _words[index].SetHidden(true);
                    hiddenWords++;

                    _hiddenWordCount++;

                    if (_hiddenWordCount >= _wordCount)
                    {
                        _isHidden = true;
                    }
                }
            }
            else { return; }
        }
    }

    public bool CheckHidden()
    {
        return _isHidden;
    }
}