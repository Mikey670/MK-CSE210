using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        Random random = new Random();

        while (!done)
        {
            int countGuesses = 0;

            int magicNumber = random.Next(1, 101);
            Console.WriteLine("I've picked a random number between 1 and 100, try and guess what it is!");

            // Console.Write("What is the magic number? ");
            // int magicNumber = int.Parse(Console.ReadLine());

            bool correct = false;

            while (!correct)
            {
                countGuesses ++;

                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());

                if (guess == magicNumber)
                {
                    correct = true;
                    Console.WriteLine($"You guessed it after {countGuesses} guesses!");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.Write("Would you like to keep playing? ");
            string keepPlaying = Console.ReadLine();

            if (keepPlaying != "yes")
            {
                done = true;
            }
        }

    }
}