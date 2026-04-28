using System;

class Program
{
    static void Main()
    {

        //TASK 1

        Console.WriteLine("===== TASK 1 =====");

        Console.Write("Enter a number (1-100): ");
        int num = int.Parse(Console.ReadLine());

        if (num < 1 || num > 100)
        {
            Console.WriteLine("Error: number is out of range.");
        }
        else
        {
            if (num % 3 == 0 && num % 5 == 0)
                Console.WriteLine("Fizz Buzz");
            else if (num % 3 == 0)
                Console.WriteLine("Fizz");
            else if (num % 5 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(num);
        }

        Console.WriteLine();

        //TASK 2

        Console.WriteLine("===== TASK 2 =====");

        Console.Write("Enter value: ");
        double value = double.Parse(Console.ReadLine());

        Console.Write("Enter percent: ");
        double percent = double.Parse(Console.ReadLine());

        double result = value * percent / 100;

        Console.WriteLine("Result: " + result);

        Console.WriteLine();


        // TASK 3 

        Console.WriteLine("===== TASK 3 =====");

        Console.Write("Enter first digit: ");
        int d1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second digit: ");
        int d2 = int.Parse(Console.ReadLine());

        Console.Write("Enter third digit: ");
        int d3 = int.Parse(Console.ReadLine());

        Console.Write("Enter fourth digit: ");
        int d4 = int.Parse(Console.ReadLine());

        int number = d1 * 1000 + d2 * 100 + d3 * 10 + d4;

        Console.WriteLine("Result number: " + number);
    }
}