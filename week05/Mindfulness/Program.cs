using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Creativity and Exceeding Requirements:
    // 1. Added a new Gratitude Activity that helps users express gratitude by listing things they're thankful for.
    // 2. Implemented smart prompt rotation: ensures all prompts/questions are used at least once before repeating in a session.
    // 3. Enhanced breathing animation: text grows quickly at first then slows down, creating a more immersive experience.
    // 4. Added activity logging: tracks how many times each activity was performed and saves/loads from a file.
    // 5. Improved user experience with better feedback and session summaries.

    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();
    private static string _logFile = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        LoadLog();
        
        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            Activity activity = null;
            string activityName = "";
            
            switch (choice)
            {
                case 1: 
                    activity = new BreathingActivity(); 
                    activityName = "Breathing";
                    break;
                case 2: 
                    activity = new ReflectionActivity(); 
                    activityName = "Reflection";
                    break;
                case 3: 
                    activity = new ListingActivity(); 
                    activityName = "Listing";
                    break;
                case 4: 
                    activity = new GratitudeActivity(); 
                    activityName = "Gratitude";
                    break;
            }

            if (activity != null)
            {
                activity.Run();
                LogActivity(activityName);
                DisplaySessionSummary();
            }
        }
        
        SaveLog();
        Console.WriteLine("Thank you for using Mindfulness Activities!");
    }

    private static void LogActivity(string activityName)
    {
        if (_activityLog.ContainsKey(activityName))
        {
            _activityLog[activityName]++;
        }
        else
        {
            _activityLog[activityName] = 1;
        }
    }

    private static void DisplaySessionSummary()
    {
        Console.WriteLine("\n--- Session Summary ---");
        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key} Activity: {entry.Value} times");
        }
        Console.WriteLine("-----------------------\n");
    }

    private static void LoadLog()
    {
        if (File.Exists(_logFile))
        {
            foreach (string line in File.ReadLines(_logFile))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string activity = parts[0].Trim();
                    int count = int.Parse(parts[1].Trim());
                    _activityLog[activity] = count;
                }
            }
        }
    }

    private static void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter(_logFile))
        {
            foreach (var entry in _activityLog)
            {
                writer.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
