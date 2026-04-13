using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create different activities
        List<Activity> activities = new List<Activity>();

        // Running activity
        Running running = new Running("03 Nov 2022", 30, 3.0); // 30 min, 3 miles
        activities.Add(running);

        // Cycling activity
        Cycling cycling = new Cycling("04 Nov 2022", 45, 15.0); // 45 min, 15 mph
        activities.Add(cycling);

        // Swimming activity
        Swimming swimming = new Swimming("05 Nov 2022", 60, 20); // 60 min, 20 laps
        activities.Add(swimming);

        // Display summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
