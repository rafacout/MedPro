namespace MedPro.Api.Models;

public class CreateUserModel
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}