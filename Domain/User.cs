namespace Domain;

public sealed class User
{
    public Guid Id { get; init; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; set; }
}
