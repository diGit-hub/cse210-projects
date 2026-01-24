using System;

// Exceeding Requirements:
// I used the System.Text.Json library to save and load the journal files as suggested by the activity:
// Save or load your document to a database or use a different library or format such as JSON for storage.
// Now even if the file is saved as .txt it will still work, but inside it's JSON like formatted.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select your next action:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Write
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);

                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = date;
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                // Display
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Load
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                // Save
                Console.WriteLine("What is the filename?");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                // Quit
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}