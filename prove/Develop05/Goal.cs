public abstract class Goal
{
    //private members
    private string _name;
    private bool _isComplete = false;
    //Get/Set
    public string GetName() => _name;
    public bool GetComplete() => _isComplete;
    public void SetComplete(bool isComplete) => _isComplete = isComplete;
    //Constructor
    public Goal(string name, bool isComplete)
    {
        _name = name;
        _isComplete = isComplete;
    }
    //Abstract Methods
    public abstract int MarkProgress(int progress);
    public abstract void DisplayGoal();
    public abstract string SaveString();
}