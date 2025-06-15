public class ListingActivity : Activity
{
    string[] _questions;
    Random _rng = new Random();

    public ListingActivity(string name, string disc, int duration, string[] questions) : base(name, disc, duration)
    {
        _questions = questions;
    }

    string GetRandomQuestion() => _questions[_rng.Next(_questions.Length)];

    int TakeTimedResponses()
    {
        DateTime startTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(GetDuration());
        DateTime endTime = startTime.Add(timeSpan);

        int entries = 0;

        while (DateTime.Compare(DateTime.Now, endTime) < 0)
        {
            Console.Write("> ");
            Console.ReadLine();
            entries++;
        }

        return entries;
    }

    public void RunActivity()
    {
        SetDuration(PrintInstructions());

        if (GetDuration() < 0)
        {
            Console.WriteLine("ERROR: Invalid Duration Selection");
            return;
        }

        Console.Write("\n" + GetRandomQuestion() + " ");
        Wait(10000, "s", ".,..,...");
        Console.WriteLine("");

        Console.WriteLine("Start Now!");

        Console.WriteLine($"You listed {TakeTimedResponses()} items!");

        PrintEndMessage();
    }
}