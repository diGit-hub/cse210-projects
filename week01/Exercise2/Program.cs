using System;

class Program
{
    static void Main(string[] args)
    {
        // A >= 90
        // B >= 80
        // C >= 70
        // D >= 60
        // F < 60
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";

        //Determine letter
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }

        //Determine sign
        if (letter != "F")
        {
            if (grade % 10 >= 7 || grade == 100)
            {
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (grade % 10 <= 3)
            {
                sign = "-";
            }

        }

        //Print letter and sign
        Console.WriteLine($"Your grade is {letter}{sign}!");

        //Determine if passed and print
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!!!");
        }
        else
        {
            Console.WriteLine("You didn't passed. Give your best next time!");
        }
    }
}