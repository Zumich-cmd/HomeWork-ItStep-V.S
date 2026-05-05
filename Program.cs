using System;

// ===================== TASK 1 =====================

Console.WriteLine("===== TASK 1 =====");

try
{
    Console.Write("Enter square size: ");
    int size = int.Parse(Console.ReadLine());

    Console.Write("Enter symbol: ");
    char symbol = char.Parse(Console.ReadLine());

    DrawSquare(size, symbol);
}
catch
{
    Console.WriteLine("Input error!");
}

Console.WriteLine();


// ===================== TASK 4 =====================

Console.WriteLine("===== TASK 4 =====");

Website site = new Website();
site.Input();
site.Output();

Console.WriteLine();


// ===================== TASK 5 =====================

Console.WriteLine("===== TASK 5 =====");

Magazine magazine = new Magazine();
magazine.Input();
magazine.Output();


// ===================== METHODS =====================

void DrawSquare(int size, char symbol)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            Console.Write(symbol);
        }
        Console.WriteLine();
    }
}


// ===================== CLASS WEBSITE =====================

class Website
{
    private string name;
    private string path;
    private string description;
    private string ip;

    public void Input()
    {
        Console.Write("Enter website name: ");
        name = Console.ReadLine();

        Console.Write("Enter website path: ");
        path = Console.ReadLine();

        Console.Write("Enter website description: ");
        description = Console.ReadLine();

        Console.Write("Enter website IP: ");
        ip = Console.ReadLine();
    }

    public void Output()
    {
        Console.WriteLine("Website name: " + name);
        Console.WriteLine("Website path: " + path);
        Console.WriteLine("Website description: " + description);
        Console.WriteLine("Website IP: " + ip);
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetPath(string path)
    {
        this.path = path;
    }

    public string GetPath()
    {
        return path;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetIp(string ip)
    {
        this.ip = ip;
    }

    public string GetIp()
    {
        return ip;
    }
}


// ===================== CLASS MAGAZINE =====================

class Magazine
{
    private string name;
    private int year;
    private string description;
    private string phone;
    private string email;

    public void Input()
    {
        Console.Write("Enter magazine name: ");
        name = Console.ReadLine();

        Console.Write("Enter foundation year: ");
        year = int.Parse(Console.ReadLine());

        Console.Write("Enter magazine description: ");
        description = Console.ReadLine();

        Console.Write("Enter contact phone: ");
        phone = Console.ReadLine();

        Console.Write("Enter contact email: ");
        email = Console.ReadLine();
    }

    public void Output()
    {
        Console.WriteLine("Magazine name: " + name);
        Console.WriteLine("Foundation year: " + year);
        Console.WriteLine("Description: " + description);
        Console.WriteLine("Phone: " + phone);
        Console.WriteLine("Email: " + email);
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetYear(int year)
    {
        this.year = year;
    }

    public int GetYear()
    {
        return year;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetPhone(string phone)
    {
        this.phone = phone;
    }

    public string GetPhone()
    {
        return phone;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }

    public string GetEmail()
    {
        return email;
    }
}