namespace Application.Users;

public sealed record ChangePasswordRequest(Guid Id, string OldPassword, string NewPassword);
