public class ListeningActivity : Activity
{
    private List<string> _prompts;

    public ListeningActivity(string name, string description, List<string> prompts)
        : base(name, description)
    {
        _prompts = prompts;
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        double duration = getDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(5);
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {GetPrompt()} --- ");
        Console.Write("You may begin in: ");
        Timer(5);
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        DisplayEndingMessage(duration);
        Console.Clear();
    }

    public string GetPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
