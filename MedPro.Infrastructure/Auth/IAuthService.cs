﻿namespace MedPro.Infrastructure.Auth;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role);
}