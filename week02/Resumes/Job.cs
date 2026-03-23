using System;

public class Job
{
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    public Job(string company, string jobTitle, string startYear, string endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = int.Parse(startYear);
        _endYear = int.Parse(endYear); 
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle}  {_company}  {_startYear} - {_endYear}");
    }
}