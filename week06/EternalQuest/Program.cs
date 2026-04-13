using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save/Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
                    int type = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Points: ");
                    int points = int.Parse(Console.ReadLine());

                    if (type == 1)
                        manager.AddGoal(new SimpleGoal(name, desc, points));
                    else if (type == 2)
                        manager.AddGoal(new EternalGoal(name, desc, points));
                    else if (type == 3)
                    {
                        Console.Write("Target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    break;

                case 2:
                    manager.ShowGoals();
                    break;

                case 3:
                    manager.ShowGoals();
                    Console.Write("Which goal did you accomplish? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;

                case 4:
                    manager.ShowScore();
                    break;

                case 5:
                    Console.WriteLine("1=Save, 2=Load");
                    int sl = int.Parse(Console.ReadLine());
                    if (sl == 1)
                        manager.SaveGoals("goals.txt");
                    else
                        manager.LoadGoals("goals.txt");
                    break;
            }
        }
    }
}
