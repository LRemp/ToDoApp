namespace Core.DTOs;

public class UserUpdatePasswordDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
}