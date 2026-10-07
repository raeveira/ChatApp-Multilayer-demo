using Domain;
namespace Application.Users;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, PasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<User?> GetByIdAsync(Guid id) => _userRepository.GetByIdAsync(id);
    public Task<IEnumerable<ShowUsersResponse>> GetAllAsync() => _userRepository.GetAllAsync();

    public async Task AddAsync(CreateUserRequest user)
    {
        // Check if username already exists
        var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
        if (existingUser != null)
            throw new InvalidOperationException("Username already exists.");

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Username = user.Username,
            Email = user.Email,
            PasswordHash = _passwordHasher.Hash(user.Password),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(newUser);
    }

    public async Task UpdateAsync(UpdateUserRequest request)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("User not found.");

        var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
        if (existingUser != null && existingUser.Id != request.Id)
            throw new InvalidOperationException("Username already exists.");

        user.Username = request.Username;
        user.Email = request.Email;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
    }

    public async Task ChangePasswordAsync(ChangePasswordRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("User not found.");

        if (!_passwordHasher.Verify(request.OldPassword, user.PasswordHash))
            throw new InvalidOperationException("Old password is incorrect.");

        user.PasswordHash = _passwordHasher.Hash(request.NewPassword);
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
    }

    public Task DeleteAsync(Guid id) => _userRepository.DeleteAsync(id);
}
