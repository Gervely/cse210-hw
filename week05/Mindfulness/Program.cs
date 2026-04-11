using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            Activity activity = null;
            switch (choice)
            {
                case 1: activity = new BreathingActivity(); break;
                case 2: activity = new ReflectionActivity(); break;
                case 3: activity = new ListingActivity(); break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}
