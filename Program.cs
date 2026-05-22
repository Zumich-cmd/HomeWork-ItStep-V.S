using System;

class Program
{
    static void Main()
    {
        // PASSWORD

        Console.Write("Enter password: ");
        string userPassword = Console.ReadLine();

        PasswordValidator password =
            new PasswordValidator(userPassword);

        if (password.Validate())
            Console.WriteLine("Password is valid");
        else
            Console.WriteLine("Password is NOT valid");

        Console.WriteLine();


        // EMAIL

        Console.Write("Enter email: ");
        string userEmail = Console.ReadLine();

        EmailValidator email =
            new EmailValidator(userEmail);

        if (email.Validate())
            Console.WriteLine("Email is valid");
        else
            Console.WriteLine("Email is NOT valid");
    }
}
