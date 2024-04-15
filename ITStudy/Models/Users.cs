namespace ITStudy.Models;

public class Users
{
    public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
    public string UserName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Phone { get; set; } = string.Empty;
    public required string Password { get; set; }
    public string Role { get; set; } = string.Empty;
    public string? Image { get; set; }
}
public class Users_Register
{
    public string UserName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Phone { get; set; } = string.Empty;
    public required string Password { get; set; }
    public string Role { get; set; } = string.Empty;
}
