/*
The Journal class keeps and manages a list of journal entries. It can print, save, and load a journal.csv
*/
using System.Text;

public class Journal
{
    //declare statics
    private static string separator = "|";
    private static string[] headings = {"Title", "Date", "Prompt", "Text"};
    //declare publics
    public List<Entry> _entries = new List<Entry>();

    public void PrintJournal() //print all entries in the journal
    {
        foreach (Entry e in _entries)
        {  
            Console.WriteLine("");
            e.PrintEntry();
        }
    }

    public void Load() //load a journal
    {
        Console.Write("What is the name of the csv you want to load? (do not include extension) ");
        string fileName = Console.ReadLine();

        _entries = new List<Entry>();
        
        try
        {
            string[] lines = File.ReadAllLines($@".\{fileName}.csv");

            bool hasSkipped = false;
                    
            foreach (string i in lines)
            {
                if (hasSkipped)
                {
                    string[] input = i.Split(separator);

                    Entry e = new Entry();

                    e._title = input[0];
                    e._date = input[1];
                    e._prompt = input[2];
                    e._text = input[3];

                    _entries.Add(e);
                }
                hasSkipped = true;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("File could not be loaded, ensure that file name is correct.");
            return;
        }

        Console.WriteLine($"Succesfully loaded \"{fileName}.csv\"");
    }

    public void Save() //Save the journal, overwriting the file.
    {
        Console.Write("What would you like to name your file? (do not include extension) ");
        string fileName = Console.ReadLine();

        string file = $@".\{fileName}.csv";
        StringBuilder o = new StringBuilder();

        o.AppendLine(string.Join(separator, headings));

        foreach (Entry e in _entries)
        {
            string[] line = {e._title, e._date, e._prompt, e._text};
            o.AppendLine(string.Join(separator, line));
        }

        try
        {
            File.WriteAllText(file, o.ToString());
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to save file");
            return;
        }

        Console.WriteLine($"File saved as {fileName}.csv");
    }
}