namespace BSDSalzburg2024.Auth;

public class UserSession
{
    public required string Username { get; set; }

    public required string Role { get; set; }

    public string? SupersededUsername { get; set; }

    public string? SupersededRole { get; set; }
}
