using System;

namespace WizLib.Application.Seed
{
    public class CategoryInitializer
    {
        private static readonly string[] Categories =
        {
            "Fantasy",
            "Adventure",
            "Romance",
            "Contemporary",
            "Dystopian",
            "Mystery",
            "Horror",
            "Thriller",
            "Paranormal",
            "Historical fiction",
            "Science Fiction",
            "Memoir",
            "Cooking",
            "Art",
            "Self-help / Personal",
            "Development",
            "Motivational",
            "Health",
            "History",
            "Travel",
            "Guide / How-to",
            "Families & Relationships",
            "Humor",
            "Children’s"
        };

        private static readonly int Length = Categories.Length;

        public static string Category()
        {
            var random = new Random();

            return $"{Categories[random.Next(Length)]} ({Guid.NewGuid().ToString()[..6]})";
        }
    }
}
