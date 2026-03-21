using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            

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
                Console.WriteLine("You guessed it!");
            }

        }
        Console.WriteLine("Thanks for playing!");

        while (true)
        {
            Console.Write("Do you play again? yes ");
            string answerFromUser = Console.ReadLine().ToLower();

            if (answerFromUser == "yes")
            {
                magicNumber = randomGenerator.Next(1, 101);
                guess = -1;
                Console.WriteLine("Great! Let's play again!");
            }

            else
            {
                Console.WriteLine("Thanks for playing! Goodbye!");
                break;
            }
        }                   
    }
}
