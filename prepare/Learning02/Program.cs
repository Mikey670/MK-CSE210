using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume();

        resume._name = "Bella";

        resume._jobs.Add(new Job());
        resume._jobs.Add(new Job());
        resume._jobs.Add(new Job());

        resume._jobs[0]._title = "Calf";
        resume._jobs[0]._company = "Big Milk Co.";
        resume._jobs[0]._startYear = 2019;
        resume._jobs[0]._endYear = 2021;

        resume._jobs[1]._title = "Milking Cow";
        resume._jobs[1]._company = "Big Milk Co.";
        resume._jobs[1]._startYear = 2021;
        resume._jobs[1]._endYear = 2025;

        resume._jobs[2]._title = "Steak";
        resume._jobs[2]._company = "Martin's Freezer Foods";
        resume._jobs[2]._startYear = 2025;
        resume._jobs[2]._endYear = 2025;

        resume.Display();
    }
}