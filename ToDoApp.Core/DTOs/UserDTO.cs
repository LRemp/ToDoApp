﻿namespace Core.DTOs;

public class UserDTO
{
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}