public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        double duration = getDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(5);
        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            Countdown(_rand.Next(4, 7));
            Console.WriteLine();
            Console.Write("Breathe out... ");
            Countdown(_rand.Next(4, 7));
            Console.WriteLine();
            Console.WriteLine();
        }
        DisplayEndingMessage(duration);
        Console.Clear();
    }
}