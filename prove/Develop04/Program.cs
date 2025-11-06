using System;

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();

        BreathingActivity breathingActivity = new BreathingActivity(
            "Breathing Activity",
            "This activity will help you relax by walking your through breathing in and out slowly. " + 
            "Clear your mind and focus on your breathing"
        );

        ReflectionActivity reflectionActivity = new ReflectionActivity(
            "Reflection Activity",
            "This activity will help you reflect on time in your life when you have shown strength and resilence. " +
            "This will help you recognize the power you have and how you can use it in other aspects of your life.",
            new List<string>
            {

                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            },
            new List<string>
            {
                "Why was this experience meaningful to you?",
                "How can you apply what you learned from this experience " +
                "in the future?"
            }
        );

        ListeningActivity listeningActivity = new ListeningActivity(
            "Listening Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area",
            new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            }
        );

        activities.Add(breathingActivity);
        activities.Add(reflectionActivity);
        activities.Add(listeningActivity);

        while (true)
        {
            DisplayMenu();
            int choice = GetChoice(1, 4);

            if (choice == 4)
            {
                break;
            }

            RunChosenActivity(choice, activities);
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Select one of the following choices:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listening Activity");
        Console.WriteLine("4. Quit");
        Console.Write("What would you like to do? ");
    }

    public static int GetChoice(int min, int max)
    {
        while (true)
        {
            try
            {
                string choice = Console.ReadLine();
                int number = int.Parse(choice);
                if (number >= min && number <= max)
                {
                    return number;
                }
                Console.WriteLine($"Invalid option. Enter a number {min} - {max}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid option. Enter a number {min} - {max}.");
            }
        }
    }

    public static void RunChosenActivity(int choice, List<Activity> activities)
    {
        Console.Clear();
        activities[choice - 1].RunActivity();
    }
}