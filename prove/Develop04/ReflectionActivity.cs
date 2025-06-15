public class ReflectionActivity : Activity
{
    string[] _prompts;
    string[] _questions;
    Random _rng = new Random();

    public ReflectionActivity(string name, string disc, int duration, string[] prompts, string[] questions) : base(name, disc, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    string GetRandomPrompt() => _prompts[_rng.Next(_prompts.Length)];
    string GetRandomQuestion() => _questions[_rng.Next(_questions.Length)];

    public void RunActivity()
    {
        SetDuration(PrintInstructions());

        if (GetDuration() < 0)
        {
            Console.WriteLine("ERROR: Invalid Duration Selection");
            return;
        }

        int msToWait = GetDuration() * 1000;
        int questionTime = 10000;


        Console.Write("\n" + GetRandomPrompt() + " ");
        Wait(10000, "s", ".,..,...");

        Console.WriteLine("");

        while (msToWait > 0)
        {
            Console.Write("\n" + GetRandomQuestion() + " ");
            Wait(int.Min(msToWait, questionTime), "c", "?!:.", 500);
            msToWait -= questionTime;
            Console.WriteLine();
        }

        PrintEndMessage();
    }
}