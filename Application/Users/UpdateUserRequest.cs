namespace Application.Users;

public sealed record UpdateUserRequest(Guid Id, string Username, string Email);