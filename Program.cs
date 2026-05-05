using System;

class Product
{
    private string name;
    private int quantity;
    private double price;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value >= 0)
                quantity = value;
            else
                quantity = 0;
        }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                price = 0;
        }
    }

    public Product()
    {
        name = "";
        quantity = 0;
        price = 0;
    }

    public Product(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public static Product operator +(Product product, int value)
    {
        product.Quantity += value;
        return product;
    }

    public static Product operator -(Product product, int value)
    {
        product.Quantity -= value;
        return product;
    }

    public static bool operator ==(Product p1, Product p2)
    {
        return p1.Price == p2.Price;
    }

    public static bool operator !=(Product p1, Product p2)
    {
        return p1.Price != p2.Price;
    }

    public static bool operator >(Product p1, Product p2)
    {
        return p1.Quantity > p2.Quantity;
    }

    public static bool operator <(Product p1, Product p2)
    {
        return p1.Quantity < p2.Quantity;
    }

    public void Show()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Quantity: " + Quantity);
        Console.WriteLine("Price: " + Price);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== TASK 6 =====");

        Product p1 = new Product("Laptop", 10, 1200);
        Product p2 = new Product("Phone", 5, 1200);

        Console.WriteLine("Product 1:");
        p1.Show();

        Console.WriteLine();

        Console.WriteLine("Product 2:");
        p2.Show();

        Console.WriteLine();

        p1 = p1 + 5;
        Console.WriteLine("Product 1 after +5:");
        p1.Show();

        Console.WriteLine();

        p2 = p2 - 10;
        Console.WriteLine("Product 2 after -10:");
        p2.Show();

        Console.WriteLine();

        Console.WriteLine("Compare by price:");
        Console.WriteLine("p1 == p2: " + (p1 == p2));
        Console.WriteLine("p1 != p2: " + (p1 != p2));

        Console.WriteLine();

        Console.WriteLine("Compare by quantity:");
        Console.WriteLine("p1 > p2: " + (p1 > p2));
        Console.WriteLine("p1 < p2: " + (p1 < p2));
    }
}