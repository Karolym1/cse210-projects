using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds core requirements: When words are hidden, trailing punctuation is preserved
        // (example: "paths." becomes "_____." instead of "_____").

        // 1) Create the reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // 2) Create the scripture text
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                      "In all thy ways acknowledge him, and he shall direct thy paths.";

        // 3) Create the scripture object
        Scripture scripture = new Scripture(reference, text);

        // 4) Main loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type 'quit' to end: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        // Final display (if fully hidden)
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden. Program finished.");
        }
    }
}
