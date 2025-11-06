public abstract class Activity
{
    protected string _name;
    protected string _description;

    protected Random _rand = new Random(); 

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public abstract void RunActivity();

    
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welciome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
    }

    public void DisplayEndingMessage(double seconds)
    {
        Console.WriteLine($"Well done!");
        Timer(5);
        Console.WriteLine($"You have completed another {seconds} seconds of the {_name}.");
        Timer(5);
    }

    public double getDuration()
    {
        Console.WriteLine("How long, in seconds, would you like for your session?");
        while (true)
        {
            try
            {
                string choice = Console.ReadLine();
                double number = double.Parse(choice);
                if (number > 0)
                {
                    return number;
                }
                Console.WriteLine($"Invalid duration");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid duration");
            }
        }
    }
    public void Timer(int seconds)
    {
        foreach (char c in "|/-\\|/-\\")
        {
            Console.Write(c);
            Thread.Sleep(seconds * 1000 / 8);
            Console.Write("\b \b"); // Erase the character
        }

    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the number
        }
    }
}
