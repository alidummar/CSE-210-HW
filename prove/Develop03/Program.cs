using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // create a new scripture object
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // clear the console screen and display the complete scripture
        Console.Clear();
        Console.WriteLine(scripture.ToString());

        // prompt the user to press enter or type "quit"
        string input;
        do
        {
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit:");
            input = Console.ReadLine();

            // hide a few random words and re display the scripture
            if (string.IsNullOrWhiteSpace(input))
            {
                scripture.HideWords(3);
                Console.Clear();
                Console.WriteLine(scripture.ToString());
            }

        } while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase));
    }
}

class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        this.words = new List<Word>();
        string[] textWords = text.Split(' ');
        for (int i = 0; i < textWords.Length; i++)
        {
            words.Add(new Word(textWords[i]));
        }
    }

    public void HideWords(int count)
    {
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = new Random().Next(words.Count);
            if (!words[index].IsHidden)
            {
                words[index].IsHidden = true;
                hiddenCount++;
            }
        }
    }

    public override string ToString()
    {
        string result = reference.ToString() + "\n";
        for (int i = 0; i < words.Count; i++)
        {
            result += words[i].ToString() + " ";
        }
        return result.Trim();
    }
}

class ScriptureReference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(' ');
        book = parts[0];
        string[] verseParts = parts[1].Split(':');
        chapter = int.Parse(verseParts[0]);
        if (verseParts[1].Contains("-"))
        {
            string[] rangeParts = verseParts[1].Split('-');
            startVerse = int.Parse(rangeParts[0]);
            endVerse = int.Parse(rangeParts[1]);
        }
        else
        {
            startVerse = int.Parse(verseParts[1]);
            endVerse = startVerse;
        }
    }

    public override string ToString()
    {
        if (startVerse == endVerse)
        {
            return $"{book} {chapter}:{startVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public override string ToString()
    {
        if (IsHidden)
        {
            return new string('_', Text.Length);
        }
        else
        {
            return Text;
        }
    }
}
