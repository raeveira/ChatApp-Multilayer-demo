using Domain;
namespace Application.Users;

public interface IUserRepository
{
    // Defined in Application, used by Infrastructure.
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<ShowUsersResponse>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
