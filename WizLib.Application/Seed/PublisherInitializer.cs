using System;

namespace WizLib.Application.Seed
{
    public class PublisherInitializer
    {
        private static readonly string[] Publishers =
        {
            "Penguin Random House",
            "Hachette Livre",
            "HarperCollins",
            "Macmillan Publishers",
            "Simon & Schuster",
            "McGraw-Hill Education",
            "Houghton Mifflin Harcourt",
            "Pearson Education",
            "Scholastic",
            "Cengage Learning",
            "Springer Nature",
            "Wiley (John Wiley & Sons)",
            "Oxford University Press",
            "Kodansha",
            "Shueisha",
            "Grupo Santillana",
            "Bonnier Books",
            "Editis",
            "Klett",
            "Egmont Books"
        };

        private static readonly int Length = Publishers.Length;

        public static string Seed()
        {
            var random = new Random();

            return $"{Publishers[random.Next(Length)]} {Guid.NewGuid().ToString()[..6]}";
        }
    }
}