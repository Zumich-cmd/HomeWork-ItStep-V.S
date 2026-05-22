using System;

// TASK 1

Console.WriteLine("TASK 1");

Func<string, string> rainbowColor = delegate (string color)
{
    switch (color.ToLower())
    {
        case "red":
            return "RGB(255, 0, 0)";

        case "orange":
            return "RGB(255, 165, 0)";

        case "yellow":
            return "RGB(255, 255, 0)";

        case "green":
            return "RGB(0, 255, 0)";

        case "blue":
            return "RGB(0, 0, 255)";

        case "indigo":
            return "RGB(75, 0, 130)";

        case "violet":
            return "RGB(238, 130, 238)";

        default:
            return "Color not found";
    }
};

Console.Write("Enter rainbow color: ");
string userColor = Console.ReadLine();

Console.WriteLine(rainbowColor(userColor));

Console.WriteLine();


// TASK 2

Console.WriteLine("TASK 2");

Backpack backpack = new Backpack();

backpack.ItemAdded += delegate (string item)
{
    Console.WriteLine(item + " added to backpack");
};

backpack.ItemRemoved += delegate (string item)
{
    Console.WriteLine(item + " removed from backpack");
};

backpack.Changed += delegate ()
{
    Console.WriteLine("Backpack changed");
};

try
{
    backpack.Color = "Black";
    backpack.Brand = "Nike";
    backpack.Fabric = "Polyester";
    backpack.Weight = 1.5;
    backpack.Volume = 5;

    backpack.AddItem("Book");
    backpack.AddItem("Laptop");
    backpack.RemoveItem("Book");

    backpack.Show();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();


// TASK 3

Console.WriteLine("TASK 3");

int[] numbers = { 7, 14, 21, 5, 9, 28, 35 };

Func<int, int> countNumbers = (x) =>
{
    int count = 0;

    foreach (int n in numbers)
    {
        if (n % x == 0)
            count++;
    }

    return count;
};

Console.WriteLine("Numbers divisible by 7: " + countNumbers(7));
Console.WriteLine("Numbers divisible by 5: " + countNumbers(5));
Console.WriteLine("Numbers divisible by 3: " + countNumbers(3));



// CLASS

class Backpack
{
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Fabric { get; set; }
    public double Weight { get; set; }
    public int Volume { get; set; }

    private string[] items = new string[100];
    private int itemCount = 0;

    public delegate void BackpackHandler(string item);

    public event BackpackHandler ItemAdded;
    public event BackpackHandler ItemRemoved;

    public delegate void ChangeHandler();

    public event ChangeHandler Changed;

    public void AddItem(string item)
    {
        if (itemCount >= Volume)
            throw new Exception("Backpack is full");

        items[itemCount] = item;
        itemCount++;

        ItemAdded?.Invoke(item);
        Changed?.Invoke();
    }

    public void RemoveItem(string item)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i] == item)
            {
                for (int j = i; j < itemCount - 1; j++)
                {
                    items[j] = items[j + 1];
                }

                itemCount--;

                ItemRemoved?.Invoke(item);
                Changed?.Invoke();

                break;
            }
        }
    }

    public void Show()
    {
        Console.WriteLine("Color: " + Color);
        Console.WriteLine("Brand: " + Brand);
        Console.WriteLine("Fabric: " + Fabric);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Volume: " + Volume);

        Console.WriteLine("Items:");

        for (int i = 0; i < itemCount; i++)
        {
            Console.WriteLine("- " + items[i]);
        }
    }
}
