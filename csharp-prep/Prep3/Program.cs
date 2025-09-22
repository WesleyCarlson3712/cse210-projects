using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        string guess;
        int intGuess;
        do
        {
            Console.Write("What is your guess? ");
            guess = Console.ReadLine();
            intGuess = int.Parse(guess);
            if (intGuess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (intGuess > number)
            {
                Console.WriteLine("Lower");
            }

        } while (number != intGuess);

        Console.WriteLine("You guessed it!");
    }
}