using System;
using System.Collections.Generic;
using System.Linq;

class Company
{
    public string Name { get; set; }
    public DateTime Founded { get; set; }
    public string BusinessField { get; set; }
    public string Director { get; set; }
    public int Employees { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"{Name} | {BusinessField} | Dir: {Director} | Emp: {Employees} | {Address} | Founded: {Founded:yyyy-MM-dd}";
    }
}

class Program
{
    static void Main()
    {
        // Масив фірм
        Company[] companies =
        {
            new Company { Name = "White Food Corp",    Founded = new DateTime(2018, 3, 10), BusinessField = "Food",      Director = "John White",   Employees = 250, Address = "London" },
            new Company { Name = "Black IT Solutions", Founded = new DateTime(2020, 7, 22), BusinessField = "IT",        Director = "Alice Black",  Employees = 80,  Address = "New York" },
            new Company { Name = "Green Marketing",    Founded = new DateTime(2019, 1, 5),  BusinessField = "Marketing", Director = "Tom Green",    Employees = 130, Address = "London" },
            new Company { Name = "Blue Food Ltd",      Founded = new DateTime(2021, 11, 3), BusinessField = "Food",      Director = "Sara White",   Employees = 310, Address = "Paris" },
            new Company { Name = "Red IT Group",       Founded = new DateTime(2022, 5, 15), BusinessField = "IT",        Director = "Mike Brown",   Employees = 95,  Address = "London" },
            new Company { Name = "Smart Marketing Co", Founded = new DateTime(2017, 8, 20), BusinessField = "Marketing", Director = "Anna Black",   Employees = 200, Address = "Berlin" },
            new Company { Name = "White Space Agency",  Founded = new DateTime(2023, 2, 1),  BusinessField = "Marketing", Director = "Paul White",   Employees = 45,  Address = "London" },
            new Company { Name = "Global Food Supply", Founded = new DateTime(2016, 4, 14), BusinessField = "Food",      Director = "Leo Black",    Employees = 500, Address = "Chicago" },
            new Company { Name = "NextGen IT",         Founded = new DateTime(2015, 9, 30), BusinessField = "IT",        Director = "Nina White",   Employees = 170, Address = "London" },
            new Company { Name = "Black White Corp",   Founded = new DateTime(2021, 6, 18), BusinessField = "Finance",  Director = "Sam Black",    Employees = 60,  Address = "Tokyo" },
        };

        // Встановлюємо дату "123 дні тому" відносно сьогодні для демонстрації
        // Замінюємо одну фірму щоб запит спрацював
        companies[4].Founded = DateTime.Today.AddDays(-123);

        Print("1. All companies",
            from c in companies
            select c);

        Print("2. Companies with 'Food' in name",
            from c in companies
            where c.Name.Contains("Food")
            select c);

        Print("3. Marketing companies",
            from c in companies
            where c.BusinessField == "Marketing"
            select c);

        Print("4. Marketing or IT companies",
            from c in companies
            where c.BusinessField == "Marketing" || c.BusinessField == "IT"
            select c);

        Print("5. Companies with more than 100 employees",
            from c in companies
            where c.Employees > 100
            select c);

        Print("6. Companies with 100 to 300 employees",
            from c in companies
            where c.Employees >= 100 && c.Employees <= 300
            select c);

        Print("7. Companies in London",
            from c in companies
            where c.Address == "London"
            select c);

        Print("8. Companies where director's last name is White",
            from c in companies
            where c.Director.Split(' ')[1] == "White"
            select c);

        Print("9. Companies founded more than 2 years ago",
            from c in companies
            where (DateTime.Today - c.Founded).TotalDays > 365 * 2
            select c);

        Print("10. Companies founded exactly 123 days ago",
            from c in companies
            where (DateTime.Today - c.Founded).Days == 123
            select c);

        Print("11. Director's last name is Black AND company name contains 'White'",
            from c in companies
            where c.Director.Split(' ')[1] == "Black" && c.Name.Contains("White")
            select c);
    }

    static void Print(string title, IEnumerable<Company> result)
    {
        Console.WriteLine($"\n=== {title} ===");
        int count = 0;
        foreach (var c in result)
        {
            Console.WriteLine("  " + c);
            count++;
        }
        if (count == 0)
            Console.WriteLine("  (no results)");
        Console.WriteLine($"  Total: {count}");
    }
}