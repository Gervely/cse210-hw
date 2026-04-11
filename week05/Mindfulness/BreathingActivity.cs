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
            AnimateBreath("INHALE", 4, true);
            Console.WriteLine("Hold...");
            ShowSpinner(2);
            Console.WriteLine("Breathe out...");
            AnimateBreath("EXHALE", 6, false);
            Console.WriteLine("Hold...");
            ShowSpinner(2);
        }
        EndMessage();
    }

    private void AnimateBreath(string word, int steps, bool growing)
    {
        for (int i = growing ? 1 : steps; (growing && i <= steps) || (!growing && i >= 1); i += growing ? 1 : -1)
        {
            string breathText = new string(word[0], i);
            Console.Write(breathText);
            Thread.Sleep(500);
            Console.Write(new string('\b', breathText.Length));
            Console.Write(new string(' ', breathText.Length));
            Console.Write(new string('\b', breathText.Length));
        }
        Console.WriteLine();
    }
}
