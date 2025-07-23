using System.ComponentModel.Design;

public class Menu(string title, List<string> options)
{
    private List<string> _options = options;
    private string _title = title;
    private int _selectedOption = 0;

    public int GetChoice()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(_title);
            Console.WriteLine("Use arrow keys and press 'Enter'/'Space' to select");

            for (int i = 0; i < _options.Count; i++)
            {
                Console.Write($"    {i + 1}. {_options[i]}");
                if (i == _selectedOption) Console.WriteLine("  <----");
                else Console.WriteLine();
            }

            int keyIn = (int)Console.ReadKey(true).Key;

            if (keyIn >= 49 && keyIn <= 57 && keyIn - 49 < _options.Count) _selectedOption = keyIn - 49;
            else if ((keyIn == 38 || keyIn == 87) && _selectedOption > 0) _selectedOption--;
            else if ((keyIn == 40 || keyIn == 83) && _selectedOption < _options.Count - 1) _selectedOption++;
            else if (keyIn == 32 || keyIn == 13) return _selectedOption;
        }
    }

    public int GetLength() => _options.Count;
}