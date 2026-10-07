namespace Application.Users;

public sealed record CreateUserRequest(string Username, string Email, string Password)
{
    public CreateUserRequest() : this(string.Empty, string.Empty, string.Empty) { }
};