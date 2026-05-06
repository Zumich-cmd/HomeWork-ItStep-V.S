using System;

public class Device
{
    protected string name;
    protected string description;

    public Device(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public virtual void Sound()
    {
        Console.WriteLine("Device makes a sound");
    }

    public virtual void Show()
    {
        Console.WriteLine("Device name: " + name);
    }

    public virtual void Desc()
    {
        Console.WriteLine("Description: " + description);
    }
}

public class Kettle : Device
{
    public Kettle(string name, string description) : base(name, description) { }

    public override void Sound()
    {
        Console.WriteLine("Kettle sound: boiling water");
    }
}

public class Microwave : Device
{
    public Microwave(string name, string description) : base(name, description) { }

    public override void Sound()
    {
        Console.WriteLine("Microwave sound: beep beep");
    }
}

public class Car : Device
{
    public Car(string name, string description) : base(name, description) { }

    public override void Sound()
    {
        Console.WriteLine("Car sound: vroom vroom");
    }
}

public class Ship : Device
{
    public Ship(string name, string description) : base(name, description) { }

    public override void Sound()
    {
        Console.WriteLine("Ship sound: horn");
    }
}
