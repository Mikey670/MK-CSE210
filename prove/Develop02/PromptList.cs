/*
The prompt list has a public list of strings that serve as prompts. These prompts are stored in a seperate prompts.txt file that is included in the project.

Extra features:
I added prompt management functions to modify/veiw prompts.
    PrintPrompts()
    LoadPrompts()
    SavePrompts()
    AddPrompt()
    PopPrompt()
*/
using System.Text;

public class PromptList
{
    private string file = @".\prompts.txt";
    public List<string> _prompts;

    Random random = new Random();

    public string GeneratePrompt()
    {
        int r = random.Next(_prompts.Count);
        return _prompts[r];
    }

    public void PrintPrompts()
    {
        Console.WriteLine("The currently loaded prompts are:");
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_prompts[i]}");
        }
    }

    public void PopPrompt()
    {
        Console.Write("What prompt number do you want to remove? ");
        int index = int.Parse(Console.ReadLine());

        try
        {
            _prompts.RemoveAt(index - 1);
        }
        catch (Exception)
        {
            Console.WriteLine($"Invalid prompt number: \"{index}\".");
            return;
        }

        SavePrompts();
    }

    public void AddPrompt()
    {
        Console.Write("What is the prompt you would like to add?\n> ");
        string newPrompt = Console.ReadLine();

        _prompts.Add(newPrompt);

        SavePrompts();
    }

    public void LoadPrompts()
    {
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            _prompts.Add(line);
        }
    }

    private void SavePrompts()
    {
        StringBuilder o = new StringBuilder();

        foreach (string p in _prompts)
        {
            o.AppendLine(p);
        }

        File.WriteAllText(file, o.ToString());
    }
}