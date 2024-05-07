namespace MedPro.Application.ViewModels;

public class LoginUserViewModel
{
    public LoginUserViewModel(string userName, string role, string token)
    {
        UserName = userName;
        Role = role;
        Token = token;
    }
    
    public string UserName { get; private set; }
    public string Role { get; private set; }
    public string Token { get; private set; }
}