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
            string userChoice = myMenu.GetUserChoice();
            switch (userChoice)
            {
                case "1":
                    string newPrompt = myPromptGenerator.GetRandomPrompt();
                    string userEntry = myMenu.GetUserContent(newPrompt);
                    myJournal.AddEntry(new Entry(newPrompt, userEntry));
                    break;
                case "2":
                    myJournal.DisplayEntries();
                    break;
                case "3":
                    myJournal.SaveJournalToFile();
                    break;
                case "4":
                    myJournal.LoadJournalFromFile();
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
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nContent: {entry.Content}\n");
        }
    }

    public void SaveJournalToFile()
    {
        Console.WriteLine("Enter the filename to save your journal to:");
        string fileName = Console.ReadLine();
        // code to save the journal to a file using the specified fileName
    }

    public void LoadJournalFromFile()
    {
        Console.WriteLine("Enter the filename to load your journal from:");
        string fileName = Console.ReadLine();
        // code to load the journal from a file using the specified fileName and replace the current _entries list
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

    public string GetUserChoice()
    {
        Console.WriteLine("\nEnter your choice (1-5):");
        return Console.ReadLine();
    }

    public string GetUserContent(string prompt)
    {
        Console.WriteLine($"\n{prompt}");
        return Console.ReadLine();
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
