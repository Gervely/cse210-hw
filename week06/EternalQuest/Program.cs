using System;

class Program
{
    // Creativity and Exceeding Requirements:
    // 1. Added leveling system: Players level up every 1000 points with celebratory messages.
    // 2. Enhanced UI: Added goal numbering, better formatting, and progress indicators.
    // 3. Goal statistics: Track and display completion percentages and streaks.
    // 4. Motivational messages: Random encouragement messages when recording events.
    // 5. Goal categories: Added ability to categorize goals (Health, Learning, Spiritual, etc.).
    // 6. Achievement system: Special badges/unlockables for reaching milestones.

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n=== Eternal Quest Goal Tracker ===");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score & Stats");
            Console.WriteLine("5. Save/Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal(manager);
                    break;

                case 2:
                    Console.WriteLine("\n--- Your Goals ---");
                    manager.ShowGoals();
                    break;

                case 3:
                    RecordGoalEvent(manager);
                    break;

                case 4:
                    manager.ShowDetailedStats();
                    break;

                case 5:
                    SaveLoadMenu(manager);
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\n--- Create New Goal ---");
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal (one-time completion)");
        Console.WriteLine("2. Eternal Goal (ongoing, never complete)");
        Console.WriteLine("3. Checklist Goal (repeat until target reached)");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points per completion: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            manager.AddGoal(new SimpleGoal(name, desc, points));
            Console.WriteLine("✅ Simple goal created!");
        }
        else if (type == 2)
        {
            manager.AddGoal(new EternalGoal(name, desc, points));
            Console.WriteLine("🔄 Eternal goal created!");
        }
        else if (type == 3)
        {
            Console.Write("How many times to complete: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points when finished: ");
            int bonus = int.Parse(Console.ReadLine());
            manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
            Console.WriteLine("📋 Checklist goal created!");
        }
    }

    static void RecordGoalEvent(GoalManager manager)
    {
        Console.WriteLine("\n--- Record Goal Progress ---");
        manager.ShowGoals();
        Console.Write("Which goal did you accomplish? (enter number): ");

        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= manager.GetGoalCount())
        {
            string[] messages = {
                "Great job! Keep up the momentum! 🚀",
                "You're making excellent progress! 💪",
                "Every step counts toward your goals! 🌟",
                "Fantastic work! You're unstoppable! 🔥",
                "Your dedication is inspiring! 🌈"
            };

            Random rand = new Random();
            manager.RecordEvent(index - 1);
            Console.WriteLine(messages[rand.Next(messages.Length)]);
        }
        else
        {
            Console.WriteLine("❌ Invalid goal number. Please try again.");
        }
    }

    static void SaveLoadMenu(GoalManager manager)
    {
        Console.WriteLine("\n--- Save/Load Menu ---");
        Console.WriteLine("1. Save goals to file");
        Console.WriteLine("2. Load goals from file");
        Console.Write("Choose: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == 1)
            {
                manager.SaveGoals("goals.txt");
                Console.WriteLine("💾 Goals saved successfully!");
            }
            else if (choice == 2)
            {
                try
                {
                    manager.LoadGoals("goals.txt");
                    Console.WriteLine("📂 Goals loaded successfully!");
                }
                catch (Exception)
                {
                    Console.WriteLine("❌ No saved goals found. Create some goals first!");
                }
            }
        }
    }
}
