using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class Magazine
{
    public string Name { get; set; }
    public string Publisher { get; set; }
    public DateTime IssueDate { get; set; }
    public int Pages { get; set; }

    public Magazine() { }

    public Magazine(string name, string publisher, DateTime issueDate, int pages)
    {
        Name = name;
        Publisher = publisher;
        IssueDate = issueDate;
        Pages = pages;
    }

    public void Print()
    {
        Console.WriteLine($"  Name:      {Name}");
        Console.WriteLine($"  Publisher: {Publisher}");
        Console.WriteLine($"  Date:      {IssueDate:yyyy-MM-dd}");
        Console.WriteLine($"  Pages:     {Pages}");
    }
}

class Program
{
    const string FilePath = "magazine.json";

    static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    static void Main()
    {
        Console.WriteLine("=== Enter magazine info ===");
        Magazine magazine = InputMagazine();

        Console.WriteLine("\n=== Magazine info ===");
        magazine.Print();

        SaveToFile(magazine);

        Magazine loaded = LoadFromFile();

        Console.WriteLine("\n=== Loaded from file ===");
        loaded.Print();
    }

    static Magazine InputMagazine()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Issue date (yyyy-MM-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Pages: ");
        int pages = int.Parse(Console.ReadLine());

        return new Magazine(name, publisher, date, pages);
    }
    static void SaveToFile(Magazine magazine)
    {
        string json = JsonSerializer.Serialize(magazine, Options);
        File.WriteAllText(FilePath, json);

        Console.WriteLine($"\n=== Serialized JSON ===");
        Console.WriteLine(json);
        Console.WriteLine($"Saved to '{FilePath}'.");
    }
    static Magazine LoadFromFile()
    {
        string json = File.ReadAllText(FilePath);
        Magazine magazine = JsonSerializer.Deserialize<Magazine>(json);
        Console.WriteLine($"\nLoaded from '{FilePath}'.");
        return magazine;
    }
}