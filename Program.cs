using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("TASK 5");
        Console.WriteLine();

        PasswordValidator password =
            new PasswordValidator("mypassword123");

        Console.WriteLine("Password valid: " +
            password.Validate());

        Console.WriteLine();

        EmailValidator email =
            new EmailValidator("test@gmail.com");

        Console.WriteLine("Email valid: " +
            email.Validate());
    }
}
