using System;
using System.Collections.Generic;

// SEA CREATURE

public class SeaCreature
{
    public string Name { get; set; }
    public string Type { get; set; }

    public SeaCreature(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public void Show()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Type: " + Type);
    }
}


// OCEANARIUM

public class Oceanarium
{
    private List<SeaCreature> creatures =
        new List<SeaCreature>();

    public void AddCreature(SeaCreature creature)
    {
        creatures.Add(creature);
    }

    public void ShowAll()
    {
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].Show();
            Console.WriteLine();
        }
    }
}
