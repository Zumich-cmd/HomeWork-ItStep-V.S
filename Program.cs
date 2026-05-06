using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("TASK 2");
        Console.WriteLine();

        Device d1 = new Kettle("Kettle", "Used to boil water");
        Device d2 = new Car("Car", "Vehicle for transport");
        Device d3 = new Microwave("Microwave", "Used to heat food");
        Device d4 = new Ship("Ship", "Water transport");

        Device[] devices = { d1, d2, d3 };

        foreach (Device d in devices)
        {
            d.Show();
            d.Desc();
            d.Sound();
            Console.WriteLine();
        }
    }
}
