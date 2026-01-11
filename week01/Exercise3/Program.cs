using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepGoing = true;
        while (keepGoing)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int guess = 0;
            int tries = 0;
            Console.WriteLine("I'm imagining a number. Can you guess it?");
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                tries++;
                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {tries} tries!");
                }
            } while (magicNumber != guess);

            Console.Write("Do you want to play again? (y/N) ");
            string answer = Console.ReadLine();
            if (answer != "y")
            {
                keepGoing = false;
            }
        }
        Console.WriteLine("Bye!");
    }
}