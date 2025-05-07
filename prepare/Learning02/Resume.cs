public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>{};

    public void Display()
    {
        Console.WriteLine($"{_name}'s Resume:");
        foreach (Job i in _jobs)
        {
            i.Display();
        }
    }
}