using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("TASK 1");
        Console.WriteLine();

        Oceanarium oceanarium = new Oceanarium();

        SeaCreature c1 =
            new SeaCreature("Shark", "Fish");

        SeaCreature c2 =
            new SeaCreature("Dolphin", "Mammal");

        SeaCreature c3 =
            new SeaCreature("Octopus", "Mollusk");

        oceanarium.AddCreature(c1);
        oceanarium.AddCreature(c2);
        oceanarium.AddCreature(c3);

        oceanarium.ShowAll();
    }
}
