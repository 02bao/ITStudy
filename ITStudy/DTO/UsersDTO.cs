using ITStudy.Models;

namespace ITStudy.DTO;

public class UsersDTO
{
    public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
    public string UserName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Phone { get; set; } = string.Empty;
    public required string Password { get; set; }
    public string Role { get; set; } = string.Empty;
    public string? Image { get; set; }
    public string Token { get; set; } = string.Empty;
    public Status_Register Status { get; set; } = Status_Register.Wating;
}
public class Users_LoginDTO
{
    public string UserName { get; set; } = string.Empty;

}
public class Users_RegisterDTO
{
    public string UserName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string Phone { get; set; } = string.Empty;
    public required string Password { get; set; }
    public string Role { get; set; } = string.Empty;
}
