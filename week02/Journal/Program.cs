using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Save the journal to CSV (bonus)");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                Console.Write("Optional: How do you feel today? ");
                string emotion = Console.ReadLine();
                string dateText = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(dateText, prompt, response, emotion);
                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayJournal();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == 5)
            {
                Console.Write("Enter filename to save as CSV: ");
                string filename = Console.ReadLine();
                journal.SaveToCsv(filename);
            }
        }
    }
}
