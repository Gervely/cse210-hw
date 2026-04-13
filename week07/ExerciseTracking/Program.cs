using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learning C#", "Alice", 600);
        video1.AddComment(new Comment("Bob", "Great explanation!"));
        video1.AddComment(new Comment("Charlie", "Very helpful, thanks."));
        video1.AddComment(new Comment("Dana", "Can you cover inheritance next?"));

        Video video2 = new Video("Cooking Pasta", "Chef Mario", 300);
        video2.AddComment(new Comment("Luca", "Looks delicious!"));
        video2.AddComment(new Comment("Sophia", "I tried this recipe, amazing."));
        video2.AddComment(new Comment("Marco", "Can you show gluten-free options?"));

        Video video3 = new Video("Travel Vlog: Paris", "Emily", 900);
        video3.AddComment(new Comment("Anna", "Beautiful shots of the Eiffel Tower."));
        video3.AddComment(new Comment("James", "I want to visit Paris now!"));
        video3.AddComment(new Comment("Olivia", "Loved the editing style."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
        }
    }
}
