public class Program
{

    public static void Main()
    {
        List<string> ranks_list = new List<string>
        {
            "Novice",
            "Apprentice",
            "Adept",
            "Journeyman",
            "Expert",
            "Veteran",
            "Elite",
            "Master",
            "Grandmaster",
            "Legend"
        };
        List<Goal> goals = new List<Goal>();
        int points = 0;
        int rank = 0;
        while (true)
        {
            DisplayMenu(points, ranks_list, rank);
            int choice = GetInt(1, 6);
            RunAction(choice, goals, ref points, ref rank);
        }
    }

    public static void DisplayMenu(int points, List<string> ranks_list, int rank)
    {
        Console.WriteLine($"\nYou have {points} points.");
        Console.WriteLine($"Your rank: {ranks_list[rank]}\n");

        Console.WriteLine("Menu Options:");        
        Console.WriteLine("    1. Create Goal");
        Console.WriteLine("    2. Display Goals");
        Console.WriteLine("    3. Save Goals");
        Console.WriteLine("    4. Load Goals");
        Console.WriteLine("    5. Record Event");
        Console.WriteLine("    6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public static int GetInt(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine($"Invalid input.");
        }
    }
    public static void RunAction(int choice, List<Goal> goals, ref int points, ref int rank)
    {
        switch (choice)
        {
            case 1: 
                CreateGoal(goals); 
                break;
            case 2: 
                DisplayGoals(goals); 
                break;
            case 3: 
                Save(goals, points); 
                break;
            case 4: 
                Load(goals, points); 
                break;
            case 5: 
                RecordEvent(goals, ref points, ref rank); 
                break;
            case 6: 
                Quit(); 
                break;
            default: 
                Console.WriteLine("Invalid choice."); 
                break;
        }
    }

    public static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select goal type: ");
        int goalType = GetInt(1, 3);
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = GetInt(1, int.MaxValue);

        switch (goalType)
        {
            case 1:
                // Create SimpleGoal
                goals.Add(new SimpleGoal(name, description, points));

                break;
            case 2:
                // Create EternalGoal
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                // Create ChecklistGoal
                Console.Write("Enter completions needed: ");
                int completionsNeeded = GetInt(1, int.MaxValue);
                Console.Write("Enter bonus points: ");
                int bonusPoints = GetInt(1, int.MaxValue);
                goals.Add(new ChecklistGoal(name, description, points, bonusPoints, completionsNeeded));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public static void DisplayGoals(List<Goal> goals)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            Console.Write($"{i + 1}. {status} {goal.GetName()} ({goal.GetDescription()})");
            
             if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write($" -- Currently completed: {checklistGoal.GetTimesCompleted()}/{checklistGoal.GetCompletionsNeeded()}");
            }

            Console.WriteLine(); // move to next line
        }
    }

    public static void Save(List<Goal> goals, int points)
    {
        Console.WriteLine("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(points);

            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.ToDataString());
            }
        }
    }

    public static void Load(List<Goal> goals, int points)
    {
        Console.WriteLine("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }
        // load file if it exists
        try
        {
            string[] lines = File.ReadAllLines(filename);
            goals.Clear();
            points = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int goalPoints = int.Parse(parts[3]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool completed = bool.Parse(parts[4]);
                        goals.Add(new SimpleGoal(name, description, goalPoints, completed));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(name, description, goalPoints));
                        break;
                    case "ChecklistGoal":
                        int bonusPoints = int.Parse(parts[4]);
                        int completionsNeeded = int.Parse(parts[5]);
                        int timesCompleted = int.Parse(parts[6]);
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, goalPoints, 
                            bonusPoints, completionsNeeded, timesCompleted);
                        goals.Add(checklistGoal);
                        break;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    public static void RecordEvent(List<Goal> goals, ref int points, ref int rank)
    {
        Console.WriteLine("Your goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int choice = GetInt(1, goals.Count);
        if(!goals[choice - 1].IsComplete()){
            goals[choice - 1].RecordEvent(ref points);
            rank = Math.Min(points / 100, 9);
        }
        else
        {
            Console.WriteLine("Goal is already complete!");
        }
    }

    public static void Quit()
    {
        Environment.Exit(0);
    }
}
