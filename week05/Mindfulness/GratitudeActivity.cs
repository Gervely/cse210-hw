using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are you grateful for today?",
        "Who in your life are you thankful for?",
        "What blessings have you received recently?",
        "What simple pleasures bring you joy?",
        "What challenges have you overcome that you're grateful for?"
    };

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity will help you cultivate gratitude by reflecting on the good things in your life.") { }

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Take a moment to reflect and write down what comes to mind...");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("Gratitude item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                count++;
                Console.WriteLine($"Thank you for noting: {item}");
            }
        }
        Console.WriteLine($"You expressed gratitude for {count} things!");
        EndMessage();
    }
}