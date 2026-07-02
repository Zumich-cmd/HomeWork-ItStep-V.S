namespace FakeUsersApp.Models;

public class FakeUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{LastName,-14} {FirstName,-13} | {PhoneNumber,-13} | {Email,-28} | {Address}";
    }
}
