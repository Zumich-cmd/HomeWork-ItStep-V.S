using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] countries1 = { "Ukraine", "Germany", "France", "Poland", "Italy", "Spain", "Ukraine", "France" };
        string[] countries2 = { "France", "Italy", "Portugal", "Greece", "Ukraine", "Netherlands" };

        Console.WriteLine("Array 1: " + string.Join(", ", countries1));
        Console.WriteLine("Array 2: " + string.Join(", ", countries2));

        var difference =
            from c in countries1
            where !(from c2 in countries2 select c2).Contains(c)
            select c;

        Print("1. Difference (in Array 1 but not in Array 2)", difference);

        var intersection =
            from c in countries1
            where (from c2 in countries2 select c2).Contains(c)
            select c;

        Print("2. Intersection (common elements)", intersection);

        var union =
            (from c in countries1 select c)
            .Union(from c in countries2 select c);

        Print("3. Union (all elements, no duplicates)", union);

        var distinct =
            (from c in countries1 select c).Distinct();

        Print("4. Array 1 without duplicates", distinct);
    }

    static void Print(string title, IEnumerable<string> result)
    {
        Console.WriteLine($"\n=== {title} ===");
        var list = result.ToList();
        Console.WriteLine(list.Count > 0 ? string.Join(", ", list) : "(empty)");
        Console.WriteLine($"Count: {list.Count}");
    }
}