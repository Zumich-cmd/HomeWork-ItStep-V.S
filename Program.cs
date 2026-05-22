using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("TASK 4");
        Console.WriteLine();

        TV tv = new TV("Samsung TV");

        tv.ShowName();
        tv.TurnOn();
        tv.SetChannel(5);
        tv.TurnOff();

        Console.WriteLine();

        Radio radio = new Radio("Sony Radio");

        radio.ShowName();
        radio.TurnOn();
        radio.SetChannel(101);
        radio.TurnOff();
    }
}
