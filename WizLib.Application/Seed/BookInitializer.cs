using System;

namespace WizLib.Application.Seed
{
    public class BookInitializer
    {
        private static readonly string[] Books =
        {
            "Anna Karenina",
            "To Kill a Mockingbird",
            "The Great Gatsby",
            "One Hundred Years of Solitude",
            "A Passage to India",
            "Invisible Man",
            "Don Quixote",
            "Beloved",
            "Mrs. Dalloway",
            "Things Fall Apart",
            "Jane Eyre",
            "The Color Purple",
            "Pilgrim's Progress",
            "Robinson Crusoe",
            "Gulliver's Travels",
            "Tom Jones",
            "Clarissa",
            "Tristram Shandy",
            "Dangerous Liaisons",
            "Emma ",
            "Frankenstein ",
            "Nightmare Abbey",
            "The Black Sheep",
            "The Charterhouse of Parma",
            "The Count of Monte Cristo",
            "Sybil",
            "David Copperfield",
            "Wuthering Heights",
            "Jane Eyre"
        };

        private static readonly int Length = Books.Length;

        public static string Seed()
        {
            var random = new Random();

            return $"{Books[random.Next(Length)]} {Guid.NewGuid().ToString()[..6]}";
        }
    }
}