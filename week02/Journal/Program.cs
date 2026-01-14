using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine() ?? "";

            while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.Write("Invalid choice. Enter a number 1-5: ");
                input = Console.ReadLine() ?? "";
            }

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToString("yyyy-MM-dd");
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string fileName = Console.ReadLine() ?? "";
                journal.SaveToFile(fileName);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string fileName = Console.ReadLine() ?? "";
                journal.LoadFromFile(fileName);
            }
        }
    }
}
