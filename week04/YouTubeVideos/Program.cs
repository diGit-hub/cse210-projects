using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        
        Video howToPlay = new Video("How to Play", "Wang Chen", 300);
        howToPlay.AddComment(new Comment("Alice", "Great video!"));
        howToPlay.AddComment(new Comment("Shelter_789", "I love it!"));
        howToPlay.AddComment(new Comment("Ekaterina", "Thanks for sharing!"));
        howToPlay.AddComment(new Comment("Tang San", "Nice job!"));

        Video prank = new Video("Prank", "John Doe", 60);
        prank.AddComment(new Comment("Vitória", "Got me dying haha."));
        prank.AddComment(new Comment("Glauco", "Why would you do this???"));
        prank.AddComment(new Comment("Gato Galático", "Those videos are fake guys. Duh!"));
        prank.AddComment(new Comment("Willford", "I have an idea for a prank!"));

        Video codeAlong = new Video("Code Along", "Darya Tal", 600);
        codeAlong.AddComment(new Comment("Eva_09", "I got an error on line 2839 :("));
        codeAlong.AddComment(new Comment("BomberMan_playz", "The video starts at 00:56"));
        codeAlong.AddComment(new Comment("Waterloo", "Your keyboard sounds relaxing!"));
        codeAlong.AddComment(new Comment("Gilbert Silva", "Great video to help me sleep haha"));

        Video newGPT = new Video("New GPT announcement", "OpenAI", 455);
        newGPT.AddComment(new Comment("Melvin", "I'm curious about the new features."));
        newGPT.AddComment(new Comment("Serjão dos Foguetes", "Lauch the AGI already"));
        newGPT.AddComment(new Comment("Grace WonderWall", "Was that supposed to take my job? Haha"));
        newGPT.AddComment(new Comment("Isabelle", "I'm curious about the API pricing."));

        videos.Add(howToPlay);
        videos.Add(prank);
        videos.Add(codeAlong);
        videos.Add(newGPT);
        
        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}