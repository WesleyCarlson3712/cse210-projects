using System;

class Program
{
    public static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int scriptureIndex = random.Next(scriptures.Count);
        return scriptures[scriptureIndex];
    }
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add(new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        Scripture scripture = GetRandomScripture(scriptures);

        while (!scripture.IsCompletlyHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }
            scripture.HideWords();
        }
        Console.Clear();
        scripture.DisplayScripture();
        
    }
}