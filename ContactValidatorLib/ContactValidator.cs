using System.Text.RegularExpressions;

namespace ContactValidatorLib;

public static class ContactValidator
{
    private static readonly Regex FullNameRegex = new(
        @"^\p{L}+(?:[\s'-]\p{L}+)*$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex AgeRegex = new(
        @"^\d+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex PhoneRegex = new(
        @"^\+380\d{9}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex EmailRegex = new(
        @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static bool IsFullNameValid(string? fullName)
    {
        return !string.IsNullOrWhiteSpace(fullName)
               && FullNameRegex.IsMatch(fullName.Trim());
    }

    public static bool IsAgeValid(string? age)
    {
        return !string.IsNullOrWhiteSpace(age)
               && AgeRegex.IsMatch(age.Trim());
    }

    public static bool IsPhoneValid(string? phone)
    {
        return !string.IsNullOrWhiteSpace(phone)
               && PhoneRegex.IsMatch(phone.Trim());
    }

    public static bool IsEmailValid(string? email)
    {
        return !string.IsNullOrWhiteSpace(email)
               && EmailRegex.IsMatch(email.Trim());
    }
}
