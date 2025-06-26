using System.Runtime;

public class ChecklistGoal : Goal
{
    //private members
    private int _stepPoints;
    private int _finishPoints;
    private int _totalSteps;
    private int _currentSteps;
    //Constructor
    public ChecklistGoal(string name, bool isComplete, int stepPoints, int finishPoints, int totalSteps, int currentSteps) : base(name, isComplete)
    {
        _stepPoints = stepPoints;
        _finishPoints = finishPoints;
        _totalSteps = totalSteps;
        _currentSteps = currentSteps;
    }
    //Overrides
    public override int MarkProgress(int progress)
    {
        int pOut = 0;

        for (int i = 0; i < progress; i++)
        {
            _currentSteps++;

            if (_currentSteps == _totalSteps)
            {
                pOut += _finishPoints;
                SetComplete(true);
                return pOut;
            }

            pOut += _stepPoints;
        }
        return pOut;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{GetName()}\n     type: checklist | progress reward: {_stepPoints} | completion reward: {_finishPoints} | progress: {_currentSteps}/{_totalSteps}");
    }

    public override string SaveString()
    {
        string completed = GetComplete() ? completed = "True" : completed = "False";

        return $"c,{GetName()},{completed},{_stepPoints},{_finishPoints},{_totalSteps},{_currentSteps}";
    }
}