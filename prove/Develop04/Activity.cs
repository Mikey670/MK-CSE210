public class Activity
{
    //private vars
    string _activityName = "";
    string _activityDiscription = "";
    int _activityDuration = 0;
    //public constructors
    public Activity(string name, string disc, int duration)
    {
        _activityName = name;
        _activityDiscription = disc;
        _activityDuration = duration;
    }

    //GET / SET
    public string GetDescription()
    {
        return _activityName + "\nDiscription:\n" + _activityDiscription + "\n";
    }

    public int GetDuration()
    {
        return _activityDuration;
    }

    public void SetDescription(string description)
    {
        _activityDiscription = description;
    }

    public void SetName(string name)
    {
        _activityName = name;
    }

    public void SetDuration(int duration)
    {
        _activityDuration = duration;
    }

    //public methods
    public int PrintInstructions()
    {
        int iout = 0;

        Console.WriteLine(_activityName + "\nDiscription:\n" + _activityDiscription);
        Console.Write("Enter duration in seconds to continue> ");
        try
        {
            iout = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            return -1;
        }

        Console.Write($"Starting {_activityName} in: ");
        Wait(5000, "n", "", 1000);

        return iout;
    }

    public void PrintEndMessage()
    {
        Console.WriteLine($"Good job doing {_activityName}! You did this activity for {_activityDuration} seconds.");
        Wait(3000, "c", "|/-\\");
    }

    public void Wait(int duration, string type, string chars = "", int animDelay = 250, string splitChar = ",")
    {
        int stepNum = 0;

        // DateTime goalTime = DateTime.Now;

        // TimeSpan timeSpan = TimeSpan.FromSeconds(duration);
        // goalTime = goalTime.Add(timeSpan);
        int maxSteps = duration / animDelay;

        string[] charlist = chars.Split(splitChar);
        int charLength = 0;

        switch (type)
        {
            case "s":
                foreach (string c in charlist)
                {
                    if (c.Length > charLength) charLength = c.Length;
                }
                break;
            default:
                charLength = 1;
                break;
        }


        while (duration > 0 /*DateTime.Compare(DateTime.Now, goalTime) < 0*/)
        {
            switch (type)
            {
                case "c":
                    Console.Write(chars[stepNum % chars.Length]);
                    break;

                case "s":


                    string curChar = charlist[stepNum % charlist.Length];
                    Console.Write(curChar);

                    for (int i = 0; i < charLength - curChar.Length; i++)
                    {
                        Console.Write(' ');
                    }
                    break;

                case "n":
                    Console.Write(maxSteps - stepNum);
                    break;
                default:
                    Console.WriteLine("\nERROR: Invalid wait type");
                    break;
            }

            Thread.Sleep(int.Min(animDelay, duration));
            duration -= animDelay;

            for (int i = 0; i < charLength; i++)
            {
                Console.Write("\b");
            }

            stepNum++;
        }

        for (int i = 0; i < charLength; i++)
        {
            Console.Write(" ");
        }

    }
}