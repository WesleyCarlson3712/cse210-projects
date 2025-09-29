using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "poopie.co";
        job1._startYear = 2020;
        job1._endYear = 2222;
        job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Software Eater";
        job2._company = "murlpe.co";
        job2._startYear = 220;
        job2._endYear = 222;
        job2.Display();

        Resume myResume = new Resume();
        myResume._name = "Jon";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}