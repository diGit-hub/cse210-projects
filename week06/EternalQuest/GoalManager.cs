using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool playing = true;
        while (playing)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.Write("Select a choice from the menu:");
            string res = Console.ReadLine();
            switch (res)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
    }

    public string GetLevel()
    {
        if (_score < 100)
        {
            return "Newbie";
        }
        else if (_score < 500)
        {
            return "Beginner";
        }
        else if (_score < 1000)
        {
            return "Apprentice";
        }
        else if (_score < 2000)
        {
            return "Expert";
        }
        else if (_score < 5000)
        {
            return "Master";
        }
        return "Illuminated";
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index--;
            if (index >= 0 && index < _goals.Count)
            {
                Goal goal = _goals[index];
                int pointsEarned = 0;

                if (goal is ChecklistGoal cg)
                {
                    if (!cg.IsComplete())
                    {
                        goal.RecordEvent();
                        pointsEarned = int.Parse(goal.GetPoints());
                        if (cg.IsComplete())
                        {
                            pointsEarned += cg.GetBonus();
                        }
                    }
                    else
                    {
                        Console.WriteLine("This goal is already complete.");
                    }
                }
                else if (goal is SimpleGoal sg)
                {
                    if (!sg.IsComplete())
                    {
                        goal.RecordEvent();
                        pointsEarned = int.Parse(goal.GetPoints());
                    }
                    else
                    {
                        Console.WriteLine("This goal is already complete.");
                    }
                }
                else if (goal is EternalGoal)
                {
                    goal.RecordEvent();
                    pointsEarned = int.Parse(goal.GetPoints());
                }

                _score += pointsEarned;
                if (pointsEarned > 0)
                {
                    Console.WriteLine("Congratulations! You have earned " + pointsEarned + " points!");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");

                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(data[0], data[1], data[2]);
                        sg.SetComplete(bool.Parse(data[3]));
                        _goals.Add(sg);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], data[2]));
                        break;
                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(data[0], data[1], data[2], int.Parse(data[4]), int.Parse(data[3]));
                        cg.SetAmountCompleted(int.Parse(data[5]));
                        _goals.Add(cg);
                        break;
                }
            }
        }
    }
}
