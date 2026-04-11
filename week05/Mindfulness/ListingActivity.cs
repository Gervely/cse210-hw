using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", 
               "This activity will help you reflect on the good things in your life by listing as many as you can.") { }

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin listing items in 3 seconds...");
        Countdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        EndMessage();
    }
}
