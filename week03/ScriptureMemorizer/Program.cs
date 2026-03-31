using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string appDirectory = AppContext.BaseDirectory;
        string scriptFilePath = Path.Combine(appDirectory, "scriptures.txt");

        List<(Reference, string)> scriptures = LoadScripturesOrDefault(scriptFilePath);

        Random rand = new Random();
        var chosen = scriptures[rand.Next(scriptures.Count)];

        Scripture scripture = new Scripture(chosen.Item1, chosen.Item2);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }
        }
    }

    static List<(Reference, string)> LoadScriptures(string filePath)
    {
        List<(Reference, string)> scriptures = new List<(Reference, string)>();

        foreach (string line in File.ReadAllLines(filePath))
        {
            // Expected format: Book Chapter:Verse(s)|Text
            // Example: John 3:16|For God so loved the world...
            string[] parts = line.Split('|');
            string refPart = parts[0];
            string text = parts[1];

            string[] refSplit = refPart.Split(' ');
            string book = refSplit[0];
            string[] chapVerse = refSplit[1].Split(':');
            int chapter = int.Parse(chapVerse[0]);

            string[] verses = chapVerse[1].Split('-');
            Reference reference;
            if (verses.Length == 1)
            {
                reference = new Reference(book, chapter, int.Parse(verses[0]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }

            scriptures.Add((reference, text));
        }

        return scriptures;
    }

    static List<(Reference, string)> LoadScripturesOrDefault(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                return LoadScriptures(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lecture du fichier '{filePath}' : {ex.Message}");
                Console.WriteLine("Utilisation des versets par défaut.");
            }
        }
        else
        {
            Console.WriteLine($"Fichier non trouvé : '{filePath}'. Utilisation des versets par défaut.");
        }

        return GetDefaultScriptures();
    }

    static List<(Reference, string)> GetDefaultScriptures()
    {
        return new List<(Reference, string)>
        {
            (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son ..."),
            (new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            (new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing.")
        };
    }
}
