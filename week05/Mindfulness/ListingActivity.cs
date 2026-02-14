using System;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _usedPrompts;


    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;


        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();

        List<string> userList = GetListFromUser();
        _count = userList.Count;
        
        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();

    }

    public void GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            _prompts.AddRange(_usedPrompts);
            _usedPrompts.Clear();
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);

        string prompt = _prompts[index];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} ---");

        _prompts.RemoveAt(index);
        _usedPrompts.Add(prompt);

        Console.Write("You may begin in: ");
        ShowCountDown(5);
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        Console.WriteLine("\nYou may begin listing items:");

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        return items;
    }
}