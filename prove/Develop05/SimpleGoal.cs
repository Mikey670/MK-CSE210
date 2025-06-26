public class SimpleGoal : Goal
{
    //private members
    private int _pointReward;
    //Constructor
    public SimpleGoal(string name, bool isComplete, int pointReward) : base(name, isComplete)
    {
        _pointReward = pointReward;
    }
    //overrides
    public override int MarkProgress(int progress)
    {
        if (progress > 0)
        {
            SetComplete(true);
            return _pointReward;
        }

        return 0;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{GetName()}\n     type: one-time | reward: {_pointReward}");
    }

    public override string SaveString()
    {
        
        string completed = GetComplete() ? completed = "True" : completed = "False";

        return $"s,{GetName()},{completed},{_pointReward}";
    }
}