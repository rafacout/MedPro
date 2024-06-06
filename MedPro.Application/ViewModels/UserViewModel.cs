﻿namespace MedPro.Application.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}