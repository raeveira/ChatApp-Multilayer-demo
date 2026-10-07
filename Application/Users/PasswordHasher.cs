namespace Application.Users;
using BCrypt.Net;

public sealed class PasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Verify(password, passwordHash);
    }
}
