public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _unusedQuestionIndexes = new List<int>();

    public ReflectionActivity(string name, string description, List<string> prompts, List<string> questions)
        : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        double duration = getDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(5);
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($" --- {GetPrompt()} --- ");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Timer(5);
        Console.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetQuestion()}");
            Timer(10);
            Console.WriteLine();
        }
        DisplayEndingMessage(duration);
        Console.Clear();
    }

    public string GetPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetQuestion()
    {
        if (_unusedQuestionIndexes.Count == 0)
        {
            for (int i = 0; i < _questions.Count; i++)
            {
                _unusedQuestionIndexes.Add(i);
            }
        }
        int randomIdx = _rand.Next(_unusedQuestionIndexes.Count);
        int questionIdx = _unusedQuestionIndexes[randomIdx];
        _unusedQuestionIndexes.RemoveAt(randomIdx);
        return _questions[questionIdx];
    }
}
