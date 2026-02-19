using System;

class Program
{
    static void Main(string[] args)
    {
        //Exceeding requirements: I've added some cool levels that can be reached by gaining score (total of points).
        //They are Newbie, Beginner, Apprentice, Expert, Master and Illuminated.
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}