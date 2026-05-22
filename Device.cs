using System;

// INTERFACE

public interface IRemoteControl
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}


// ABSTRACT CLASS

public abstract class Device
{
    protected string name;

    public Device(string name)
    {
        this.name = name;
    }

    public void ShowName()
    {
        Console.WriteLine("Device: " + name);
    }
}


// TV

public class TV : Device, IRemoteControl
{
    public TV(string name) : base(name) { }

    public void TurnOn()
    {
        Console.WriteLine(name + " is turned ON");
    }

    public void TurnOff()
    {
        Console.WriteLine(name + " is turned OFF");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine(name + " channel set to " + channel);
    }
}


// RADIO

public class Radio : Device, IRemoteControl
{
    public Radio(string name) : base(name) { }

    public void TurnOn()
    {
        Console.WriteLine(name + " is turned ON");
    }

    public void TurnOff()
    {
        Console.WriteLine(name + " is turned OFF");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine(name + " frequency set to " + channel);
    }
}
