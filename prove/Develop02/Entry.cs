/*
The entry class is for indevidual intries. It keeps track of the title, prompt, date, and text of the entry.
*/

public class Entry
{
    //declare attributes
    public string _title = "";
    public string _text = "";
    public string _date = "";
    public string _prompt = "";

    public void CreateEntry(PromptList promptList)    //create new entry
    {
        //set entry attributes.
        _prompt = promptList.GeneratePrompt();

        Console.WriteLine($"{_prompt} answer below:");
        _text = Console.ReadLine();

        Console.Write("Please provide a title for your entry: ");
        _title = Console.ReadLine();

        DateTime dateTime = DateTime.Now; //get date and time of entry.
        _date = $"{dateTime.DayOfWeek}, {dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}";
    }
    
    public void PrintEntry() //print entry in appropriate format.
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"prompt: {_prompt}");
        Console.WriteLine(_text);
    }
}