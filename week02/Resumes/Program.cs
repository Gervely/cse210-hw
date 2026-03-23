using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("(Microsoft)", "Software Engineer", "2019", "2022");
        Job job2 = new Job("(Google)", "Manager", "2022", "2024");
        
        Resume myResume = new Resume();
        myResume._name = "Gervely BAZIMBAKANA";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}