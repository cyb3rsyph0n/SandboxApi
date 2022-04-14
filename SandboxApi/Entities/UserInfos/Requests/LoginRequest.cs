namespace SandboxApi.Entities.UserInfos.Requests;

/// <summary>
///     User login request
/// </summary>
public class LoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}