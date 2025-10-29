using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Alice Johnson", "Science");
        assignment.GetSummary();
        MathAssignment mathAssignment = new MathAssignment("John Doe", "Math", "7.3", "1-10");
        mathAssignment.GetHomeworkList();
        WritingAssignment writingAssignment = new WritingAssignment("Jane Smith", "History", "The Causes of World War II");
        writingAssignment.GetWritingInformation();
    }
}