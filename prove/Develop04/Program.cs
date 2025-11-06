using System;
using System.Diagnostics;
using System.Linq.Expressions;

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
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            }
        );

        ListeningActivity listeningActivity = new ListeningActivity(
            "Listening Activity",
            "This activity will help you reflect on the good things in your life by having " +
            "you list as many things as you can in a certain area",
            new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            }
        );
        BreathingActivity test = new BreathingActivity("Test", "This is a test");
        ListeningActivity test2 = new ListeningActivity("Test2", "This is another test", new List<string> { "Prompt1", "Prompt2" });
        ReflectionActivity test3 = new ReflectionActivity("Test3", "This is yet another test", new List<string> { "Prompt1", "Prompt2" }, new List<string> { "Question1", "Question2" });

        activities.Add(breathingActivity);
        activities.Add(reflectionActivity);
        activities.Add(listeningActivity);
        activities.Add(test);
        activities.Add(test2);
        activities.Add(test3);

        while (true)
        {
            DisplayMenu(activities);
            int choice = GetChoice(1, activities.Count + 1);

            if (choice == activities.Count + 1)
            {
                break;
            }

            RunChosenActivity(choice, activities);
        }
    }

    public static void DisplayMenu(List<Activity> activities)
    {
        for(int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].GetName()}");
        }
        Console.WriteLine($"{activities.Count + 1}. Quit");
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
            catch (OverflowException)
            {
                Console.WriteLine($"Invalid option. Enter a number {min} - {max}.");
            }
            catch (ArgumentNullException)
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