public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by guiding you to breathe in and out slowly.") { }

    public override void Run()
    {
        StartMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine("Breathe out...");
            Countdown(3);
        }
        EndMessage();
    }
}
