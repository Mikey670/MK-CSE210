public class Assignment
{
    string _studentName;
    string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }

    public string GetName()
    {
        return _studentName;
    }
}