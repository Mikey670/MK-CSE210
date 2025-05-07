using System;

public class Job
{
    public string _title = "";
    public string _company = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public void Display()
    {
        Console.WriteLine($"{_title} ({_company}) {_startYear}-{_endYear}");
    }
}