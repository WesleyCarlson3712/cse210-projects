using System;
using System.Runtime.CompilerServices;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, The square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} this year.");
    }
    static void Main(string[] args)
    {
        int birthYear;
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);
        PromptUserBirthYear(out birthYear);
        DisplayResult(name, squaredNumber, birthYear);
    }
}