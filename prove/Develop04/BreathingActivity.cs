public class BreathingActivity : Activity
{
    int _inDuration = 0;
    int _outDuration = 0;

    public BreathingActivity(string name, string description, int duration, int inDuration, int outDuration) : base(name, description, duration)
    {
        _inDuration = inDuration;
        _outDuration = outDuration;
    }

    public void RunActivity()
    {
        SetDuration(PrintInstructions());

        if (GetDuration() < 0)
        {
            Console.WriteLine("ERROR: Invalid Duration Selection");
            return;
        }

        int msToWait = GetDuration() * 1000;
        int msIn = _inDuration * 1000;
        int msOut = _outDuration * 1000;

        while (msToWait > 0)
        {
            Console.Write("\nBreath In:  ");
            Wait(int.Min(msIn, msToWait), "s", "'.','o','O'");
            msToWait -= msIn;

            Console.Write("\nBreath Out: ");
            Wait(int.Min(msOut, msToWait), "s", "'O','o','.'");
            msToWait -= msOut;
        }

        Console.WriteLine("");

        PrintEndMessage();
    }
}