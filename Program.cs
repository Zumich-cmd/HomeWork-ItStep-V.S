using System;

class Play : IDisposable
{
    private string _title;
    private string _author;
    private string _genre;
    private int _year;

    private bool _disposed = false;

    public Play(string title, string author, string genre, int year)
    {
        _title = title;
        _author = author;
        _genre = genre;
        _year = year;

        Console.WriteLine($"[Constructor] Play '{_title}' created.");
    }

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public string Genre
    {
        get => _genre;
        set => _genre = value;
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1000 || value > DateTime.Now.Year)
                throw new ArgumentException("Invalid year.");
            _year = value;
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Title:  {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Genre:  {_genre}");
        Console.WriteLine($"Year:   {_year}");
    }

    public override string ToString()
    {
        return $"'{_title}' by {_author} ({_genre}, {_year})";
    }

    ~Play()
    {
        Console.WriteLine($"[Destructor] Play '{_title}' is being finalized by GC.");
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            Console.WriteLine($"[Dispose] Play '{_title}' disposed manually.");
        }

        _disposed = true;
    }
}

class Program
{
    static void Main()
    {
        // --- Тест 1: звичайне використання ---
        Console.WriteLine("=== Test 1: basic usage ===");
        Play p1 = new Play("Hamlet", "William Shakespeare", "Tragedy", 1601);
        p1.PrintInfo();

        Console.WriteLine();

        // Зміна властивостей
        p1.Title = "Hamlet (revised)";
        Console.WriteLine($"Updated title: {p1.Title}");
        Console.WriteLine($"ToString: {p1}");

        Console.WriteLine();

        // --- Тест 2: using — автоматичний виклик Dispose ---
        Console.WriteLine("=== Test 2: using statement (auto Dispose) ===");
        using (Play p2 = new Play("The Cherry Orchard", "Anton Chekhov", "Comedy", 1904))
        {
            p2.PrintInfo();
        } // Dispose() викликається тут автоматично

        Console.WriteLine();

        // --- Тест 3: ручний виклик Dispose ---
        Console.WriteLine("=== Test 3: manual Dispose ===");
        Play p3 = new Play("Midsummer Night's Dream", "William Shakespeare", "Comedy", 1600);
        p3.Dispose();

        Console.WriteLine();

        // --- Тест 4: робота деструктора (GC) ---
        Console.WriteLine("=== Test 4: destructor via GC ===");
        CreateAndForget(); // Об'єкт створюється без збереження посилання

        // Примусовий збір сміття для демонстрації деструктора
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("GC cycle completed.");

        Console.WriteLine();
        Console.WriteLine("=== Program finished ===");
    }

    static void CreateAndForget()
    {
        Play temp = new Play("Othello", "William Shakespeare", "Tragedy", 1603);
        Console.WriteLine($"Created: {temp}");
    }
}