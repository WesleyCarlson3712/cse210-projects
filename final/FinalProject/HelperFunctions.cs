public class HelperFunctions
{
    private static Random _random = new Random();

    public static int GetRandInt(int min, int max)
    {
        return _random.Next(min,max);
    }

    public static double GetRandDouble()
    {
        return _random.NextDouble();
    }

    public static int GetInt(int min, int max)
    {
        while(true)
        {
            int choice;
            if(int.TryParse(Console.ReadLine(), out choice))
            {
                if(min <= choice && choice <= max)
                {
                    return choice;
                }
            }
            Console.WriteLine($"Invalid input.");
        }
    }
}