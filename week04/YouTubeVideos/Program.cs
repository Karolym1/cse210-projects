using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Take Better Photos", "Karolina Lym", 420);
        video1._comments.Add(new Comment("Maria", "This was super helpful!"));
        video1._comments.Add(new Comment("James", "Loved the tips on lighting."));
        video1._comments.Add(new Comment("Sofia", "Can you do one on posing?"));
        videos.Add(video1);

        Video video2 = new Video("Beginner Editing Workflow", "BSCPhotoPro", 600);
        video2._comments.Add(new Comment("Alex", "Saved me hours, thank you."));
        video2._comments.Add(new Comment("Nina", "The before/after examples were great."));
        video2._comments.Add(new Comment("Leo", "What software do you recommend?"));
        videos.Add(video2);

        Video video3 = new Video("Brand-Forward Headshots Explained", "Summit Studio", 510);
        video3._comments.Add(new Comment("Tina", "This is exactly what my team needs."));
        video3._comments.Add(new Comment("Omar", "Really clear explanation."));
        video3._comments.Add(new Comment("Chris", "How far in advance should we book?"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length (seconds): {video._lengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  {comment._name}: {comment._text}");
            }
        }

        Console.WriteLine("----------------------------------------");
    }
}
