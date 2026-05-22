using System;

// INTERFACE

public interface IValidator
{
    bool Validate();
}


// PASSWORD VALIDATOR

public class PasswordValidator : IValidator
{
    private string password;

    public PasswordValidator(string password)
    {
        this.password = password;
    }

    public bool Validate()
    {
        if (password.Length >= 8)
            return true;

        return false;
    }
}


// EMAIL VALIDATOR

public class EmailValidator : IValidator
{
    private string email;

    public EmailValidator(string email)
    {
        this.email = email;
    }

    public bool Validate()
    {
        if (email.Contains("@") && email.Contains("."))
            return true;

        return false;
    }
}
