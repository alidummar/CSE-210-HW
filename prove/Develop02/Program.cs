using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Menu myMenu = new Menu();
        PromptGenerator myPromptGenerator = new PromptGenerator();

        bool continueProgram = true;
        while (continueProgram)
        {
            myMenu.Display();
            string userChoice = myMenu.ReadUserChoice();
            switch (userChoice)
            {
                case "1":
                    string newPrompt = myPromptGenerator.RandomPrompt();
                    string userEntry = myMenu.ReadUserContent(newPrompt);
                    myJournal.AddEntry(new Entry(newPrompt, userEntry));
                    break;
                case "2":
                    myJournal.Display();
                    break;
                case "3":
                    myJournal.SaveJournal();
                    break;
                case "4":
                    myJournal.LoadJournal();
                    break;
                case "5":
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void Display()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nContent: {entry.Content}\n");
        }
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter the filename to save your journal to:");
        string filename = Console.ReadLine();
        // code to save the journal to a file using the specified filename
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter the filename to load your journal from:");
        string filename = Console.ReadLine();
        // code to load the journal from a file using the specified filename and replace the current entries list
    }
}

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Content { get; }

    public Entry(string prompt, string content)
    {
        Date = DateTime.Today.ToString("MM/dd/yyyy");
        Prompt = prompt;
        Content = content;
    }
}

class Menu
{
    public void Display()
    {
        Console.WriteLine("\nJournal Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
    }

    public string ReadUserChoice()
    {
        Console.WriteLine("\nEnter your choice (1-5):");
        return Console.ReadLine();
    }

    public string ReadUserContent(string prompt)
    {
        Console.WriteLine($"\n{prompt}");
        return Console.ReadLine();
    }
}

class PromptGenerator
{
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string RandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Count)];
    }
}
