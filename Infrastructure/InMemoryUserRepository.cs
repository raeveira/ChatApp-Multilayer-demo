using Application.Users;
using Domain;

namespace Infrastructure;

public class InMemoryUserRepository: IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public Task<User?> GetByIdAsync(Guid id)
    {
        var user = _users.FirstOrDefault(existingUser => existingUser.Id == id);
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        var user = _users.FirstOrDefault(existingUser => existingUser.Username == username);
        return Task.FromResult(user);
    }

    public Task<IEnumerable<ShowUsersResponse>> GetAllAsync()
    {
        IEnumerable<ShowUsersResponse> users = _users.Select(user => new ShowUsersResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        });
        return Task.FromResult(users);
    }

    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user)
    {
        var existingUser = _users.FirstOrDefault(existingUser => existingUser.Id == user.Id);
        if (existingUser != null)
        {
            _users.Remove(existingUser);
            _users.Add(user);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var user = _users.FirstOrDefault(existingUser => existingUser.Id == id);
        if (user != null)
        {
            _users.Remove(user);
        }
        return Task.CompletedTask;
    }
}
