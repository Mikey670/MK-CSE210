/*
  ____  _                                           _   _                    _____             _   __  __            _     _            _ 
 |  _ \(_)           /\                            | | (_)                  / ____|           | | |  \/  |          | |   (_)          | |
 | |_) |_  __ _     /  \   ___ _ __   ___ _ __ __ _| |_ _  ___  _ __  ___  | |  __  ___   __ _| | | \  / | __ _  ___| |__  _ _ __   ___| |
 |  _ <| |/ _` |   / /\ \ / __| '_ \ / _ \ '__/ _` | __| |/ _ \| '_ \/ __| | | |_ |/ _ \ / _` | | | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \ |
 | |_) | | (_| |  / ____ \\__ \ |_) |  __/ | | (_| | |_| | (_) | | | \__ \ | |__| | (_) | (_| | | | |  | | (_| | (__| | | | | | | |  __/_|
 |____/|_|\__, | /_/    \_\___/ .__/ \___|_|  \__,_|\__|_|\___/|_| |_|___/  \_____|\___/ \__,_|_| |_|  |_|\__,_|\___|_| |_|_|_| |_|\___(_)
           __/ |              | |                                                                                                         
          |___/               |_|                                                                                                         
By: Michael Knight
Summary:
    This is a goal management program that rewards users with XP when the accomplish a goal. Leveling up gets you a shiny new ascii trophy!
    You can make any goals: Load MikeyGoals.txt for a few goal examples
Extra Features:
    ASCII trophies:
        At levels 10 and 50, gold and silver trophies are earned. Each trophy will show the level that it was earned from.
    ProgressBar Class:
        This progress bar keeps track of progress made toward leveling up, it has several methods:
            DisplayBar(): shows the progress bar
            DisplayPercent(): shows the % of XP colected for next level-up
            DisplayPoinys(): Shows current level points compared to total.
*/
class Program
{
    //Constants
    private const int LVLXP = 1000;
    private const int DISPLAY_WIDTH = 100;

    //Player Score
    static private int _totalPoints;

    //selection
    static private int _choice = 1;
    static private int goalChoice;

    //classes
    static private List<Goal> _incompleteGoals = new List<Goal> { };
    static private List<Goal> _completeGoals = new List<Goal> { };
    static private Trophy trophy = new Trophy(0);
    static private ProgressBar progressBar = new ProgressBar(LVLXP, _totalPoints % LVLXP, DISPLAY_WIDTH);

    //MAIN
    static void Main(string[] args)
    {
        while (_choice != 0)
        {
            DisplayScore();
            _choice = ShowMenu();

            switch (_choice)
            {
                case 1:
                    Console.Write("Enter the file name (do not include extension)> ");
                    try
                    {
                        LoadFromFile(Console.ReadLine() + ".txt");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: could not load file");
                    }
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter the file name (do not include extension)> ");
                    try
                    {
                        SaveToFile(Console.ReadLine() + ".txt");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Invalid File name");
                    }
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Active Goals:");
                    DisplayGoals(_incompleteGoals);
                    Console.Write("Enter to Continue> ");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Completed Goals:");
                    DisplayGoals(_completeGoals);
                    Console.Write("Enter to Continue> ");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Active Goals:");
                    DisplayGoals(_incompleteGoals);
                    Console.Write("Select Goal to advance> ");
                    goalChoice = int.Parse(Console.ReadLine()) - 1;
                    if (goalChoice >= 0 && goalChoice <= _incompleteGoals.Count)
                    {
                        Console.WriteLine("You Selected the following Goal: ");
                        _incompleteGoals[goalChoice].DisplayGoal();
                        Console.Write("Enter Steps Completed> ");
                        _totalPoints += _incompleteGoals[goalChoice].MarkProgress(int.Parse(Console.ReadLine()));
                        if (_incompleteGoals[goalChoice].GetComplete())
                        {
                            Console.WriteLine("Congratulations! You completed the goal: " + _incompleteGoals[goalChoice].GetName());
                            _completeGoals.Add(_incompleteGoals[goalChoice]);
                            _incompleteGoals.RemoveAt(goalChoice);
                        }
                        else
                        {
                            Console.WriteLine($"Good Job!, You've made progress on your goal: \"{_incompleteGoals[goalChoice].GetName()}\"!");
                        }
                    }
                    else Console.WriteLine("ERROR: Goal does not exist");
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;

                case 6:
                    Goal newGoal = NewGoal();

                    if (newGoal == null)
                    {
                        Console.WriteLine("ERROR, Invalid Goal");
                    }
                    else
                    {
                        _incompleteGoals.Add(newGoal);
                        Console.WriteLine($"Goal \"{newGoal.GetName()}\" succesfully Created!");
                    }
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;
                case 7:
                    Console.WriteLine("Active Goals:");
                    DisplayGoals(_incompleteGoals);
                    Console.Write("Enter Goal to remove> ");
                    goalChoice = int.Parse(Console.ReadLine()) - 1;
                    if (goalChoice >= 0 && goalChoice <= _incompleteGoals.Count)
                    {
                        Console.WriteLine("You Selected the following Goal: ");
                        _incompleteGoals[goalChoice].DisplayGoal();
                        Console.Write("Confirm deletion? \n1 = yes, 0 = no> ");
                        int delete = int.Parse(Console.ReadLine());
                        if (delete == 1)
                        {
                            _incompleteGoals.RemoveAt(goalChoice);
                            Console.WriteLine("Goal was succesfully removed.");
                        }
                        else
                        {
                            Console.WriteLine("Deletion canceled!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Deletion Choice");
                    }
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;
                case 0:
                    Console.WriteLine("Good job on your goals today!");
                    break;
                default:
                    Console.WriteLine("ERROR, invalid option");
                    Console.Write("Enter to continue> ");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static private int ShowMenu()
    {
        Console.WriteLine("Options");
        Console.WriteLine("     1. Load from file");
        Console.WriteLine("     2. Save to file");
        Console.WriteLine("     3. Display active goals");
        Console.WriteLine("     4. Display goal history");
        Console.WriteLine("     5. Record progress in a goal");
        Console.WriteLine("     6. Add a new goal");
        Console.WriteLine("     7. Delete existing goal");
        Console.WriteLine("     0. Quit");
        Console.Write("Enter Option> ");
        return int.Parse(Console.ReadLine());
    }
    //Void Methods
    static private void DisplayScore()
    {
        trophy.SetLevel(_totalPoints / LVLXP);
        progressBar.SetPoints(_totalPoints % LVLXP);

        Console.Clear();

        for (int i = 0; i < DISPLAY_WIDTH; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine("");
        Console.WriteLine("Your Latest Trophy!");
        trophy.ShowTrophy();
        Console.WriteLine("Total EXP:" + _totalPoints);
        Console.WriteLine("Level Progress:");
        progressBar.DisplayBar();
        progressBar.DisplayPercent();
        Console.Write(" || ");
        progressBar.DisplayPoints();
        Console.WriteLine("EXP");
        for (int i = 0; i < DISPLAY_WIDTH; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine();
    }
    static private void DisplayGoals(List<Goal> goals)
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write(i + 1 + ". ");
            goals[i].DisplayGoal();
        }
    }

    static private Goal NewGoal()
    {
        int goalType;
        string goalName;
        int goalPoints;
        int stepPoints;
        int goalSteps;

        Console.Write("Goal Types\n     1. One-Time\n     2. Endless\n     3. Checklist\n     0. Cancel Goal Creation\nEnter Goal Type> ");
        goalType = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                Console.Write("Enter Goal Name> ");
                goalName = Console.ReadLine();

                Console.Write("Enter Point Reward> ");
                goalPoints = int.Parse(Console.ReadLine());

                return new SimpleGoal(goalName, false, goalPoints);
            case 2:
                Console.Write("Enter Goal Name> ");
                goalName = Console.ReadLine();

                Console.Write("Enter Point Reward> ");
                goalPoints = int.Parse(Console.ReadLine());

                return new EndlessGoal(goalName, false, goalPoints, 0);
            case 3:
                Console.Write("Enter Goal Name> ");
                goalName = Console.ReadLine();

                Console.Write("Enter Goal Step Count> ");
                goalSteps = int.Parse(Console.ReadLine());

                Console.Write("Enter Progress Point Reward> ");
                stepPoints = int.Parse(Console.ReadLine());

                Console.Write("Enter Completion Point Reward> ");
                goalPoints = int.Parse(Console.ReadLine());

                return new ChecklistGoal(goalName, false, stepPoints, goalPoints, goalSteps, 0);
            case 0:
                return null;
            default:
                Console.WriteLine("ERROR: Invalid Choice.");
                return null;
        }
    }

    static private void SaveToFile(string fileName)
    {
        StreamWriter sw = new StreamWriter(fileName, false);
        sw.WriteLine(_totalPoints);

        foreach (Goal g in _incompleteGoals)
        {
            sw.WriteLine(g.SaveString());
        }

        foreach (Goal g in _completeGoals)
        {
            sw.WriteLine(g.SaveString());
        }

        Console.WriteLine($"File \"{fileName}\" Was succesfully saved!");
        sw.Close();
    }

    static private void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _completeGoals = new List<Goal>();
            _incompleteGoals = new List<Goal>();

            StreamReader sr = new StreamReader(fileName);
            string line;
            bool gotPoints = false;

            while ((line = sr.ReadLine()) != null)
            {
                if (!gotPoints)
                {
                    gotPoints = true;
                    _totalPoints = int.Parse(line);
                }
                else
                {
                    Goal goal;

                    string[] comps = line.Split(',');
                    switch (comps[0])
                    {
                        case "s":
                            goal = new SimpleGoal(comps[1], bool.Parse(comps[2]), int.Parse(comps[3]));
                            break;
                        case "e":
                            goal = new EndlessGoal(comps[1], bool.Parse(comps[2]), int.Parse(comps[3]), int.Parse(comps[4]));
                            break;
                        case "c":
                            goal = new ChecklistGoal(comps[1], bool.Parse(comps[2]), int.Parse(comps[3]), int.Parse(comps[4]), int.Parse(comps[5]), int.Parse(comps[6]));
                            break;
                        default:
                            Console.WriteLine("ERROR: Invalid file format");
                            sr.Close();
                            return;
                    }

                    if (goal.GetComplete())
                    {
                        _completeGoals.Add(goal);
                    }
                    else
                    {
                        _incompleteGoals.Add(goal);
                    }
                }
            }

            DisplayScore();
            Console.WriteLine($"File \"{fileName}\" was loaded Succesfully!");
            sr.Close();
        }
        else Console.WriteLine($"ERROR: File \"{fileName}\" could not be found");
    }
}