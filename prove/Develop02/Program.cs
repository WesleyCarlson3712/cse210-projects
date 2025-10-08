using System;

class Program
{
    public static void DisplayMenu()
    {
        Console.WriteLine("Select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    public static int GetChoice()
    {
        while (true)
        {
            try
            {
                string choice = Console.ReadLine();
                int number = int.Parse(choice);

                if (number < 1 || number > 5)
                {
                    Console.WriteLine("Invalid option. Enter a number 1 - 5.");
                    continue;
                }

                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Enter a number 1 - 5.");
            }
        }
    }
    public static void ExecuteChoice(Journal journal, int choice)
    {
        switch (choice)
        {
            case 1:
                journal.AddEntry();
                break;
            case 2:
                journal.DisplayEntries();
                break;
            case 3:
                journal.LoadFile();
                break;
            case 4:
                journal.SaveFile();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
    static void Main(string[] args)
    {
        // Create and configure the PromptGenerator
        PromptGenerator promptGenerator = new PromptGenerator();
        promptGenerator._prompts.Add("What is one thing you are grateful for today?");
        promptGenerator._prompts.Add("What was the highlight of your day?");
        promptGenerator._prompts.Add("What is a challenge you faced today?");

        // Pass the PromptGenerator to the Journal
        Journal journal = new Journal(promptGenerator);

        // loop the menu until the user quits
        while (true)
        {
            DisplayMenu();
            int choice = GetChoice();
            if (choice == 5)
            {
                break;
            }
            ExecuteChoice(journal, choice);
        } 
    }
}