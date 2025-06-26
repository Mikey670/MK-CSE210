public class EndlessGoal : Goal
{
    //private members
    private int _pointReward;
    private int _timesCompleted;
    //Constructor
    public EndlessGoal(string name, bool isComplete, int pointReward, int timesCompleted) : base(name, isComplete)
    {
        _pointReward = pointReward;
        _timesCompleted = timesCompleted;
    }
    //Overrides
    public override int MarkProgress(int progress)
    {
        _timesCompleted += progress;
        return _pointReward * progress;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{GetName()}\n     type: endless | reward: {_pointReward} | times completed: {_timesCompleted}");
    }

    public override string SaveString()
    {
        string completed = GetComplete() ? completed = "True" : completed = "False";

        return $"e,{GetName()},{completed},{_pointReward},{_timesCompleted}";
    }
}