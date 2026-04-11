using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learning C#", "Alice", 600);
        Video video2 = new Video("Cooking Pasta", "Bob", 450);
        Video video3 = new Video("Travel Vlog Paris", "Charlie", 900);

        // Add comments
        video1.AddComment(new Comment("John", "Great explanation!"));
        video1.AddComment(new Comment("Sarah", "Very helpful, thanks."));
        video1.AddComment(new Comment("Mike", "Can you cover LINQ next?"));

        video2.AddComment(new Comment("Anna", "Looks delicious!"));
        video2.AddComment(new Comment("Tom", "I tried this recipe, amazing."));
        video2.AddComment(new Comment("Lucy", "Can you show a vegetarian version?"));

        video3.AddComment(new Comment("Emma", "Paris is beautiful!"));
        video3.AddComment(new Comment("David", "Loved the Eiffel Tower shots."));
        video3.AddComment(new Comment("Sophia", "Please do Rome next!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($" - {c.Author}: {c.Text}");
            }

            Console.WriteLine(); // blank line between videos
        }
    }
}
