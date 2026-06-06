using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath,
                "The quick brown fox jumps over the lazy dog.\n" +
                "The fox was very quick and the dog was very lazy.\n" +
                "A fox and a dog can be good friends.");
            Console.WriteLine($"Test file '{filePath}' created.\n");
        }

        string originalText = File.ReadAllText(filePath);

        Console.WriteLine("=== Original file content ===");
        Console.WriteLine(originalText);
        Console.WriteLine();

        Console.Write("Enter word to search: ");
        string searchWord = Console.ReadLine();

        Console.Write("Enter word to replace with: ");
        string replaceWord = Console.ReadLine();

        if (string.IsNullOrEmpty(searchWord))
        {
            Console.WriteLine("Search word cannot be empty.");
            return;
        }

        int count = 0;
        int index = 0;
        while ((index = originalText.IndexOf(searchWord, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += searchWord.Length;
        }

        if (count == 0)
        {
            Console.WriteLine($"\nWord '{searchWord}' not found in the file.");
            return;
        }

        string newText = originalText.Replace(searchWord, replaceWord, StringComparison.OrdinalIgnoreCase);

        File.WriteAllText(filePath, newText);

        Console.WriteLine();
        Console.WriteLine("=== Updated file content ===");
        Console.WriteLine(newText);

        Console.WriteLine();
        Console.WriteLine("=== Statistics ===");
        Console.WriteLine($"File:         {filePath}");
        Console.WriteLine($"Search word:  '{searchWord}'");
        Console.WriteLine($"Replace word: '{replaceWord}'");
        Console.WriteLine($"Replacements: {count}");
        Console.WriteLine($"File size before: {originalText.Length} characters");
        Console.WriteLine($"File size after:  {newText.Length} characters");
    }
}