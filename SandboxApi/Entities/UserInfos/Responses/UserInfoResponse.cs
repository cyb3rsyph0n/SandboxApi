namespace SandboxApi.Entities.UserInfos.Responses;

/// <summary>
///     Userinfo response
/// </summary>
public class UserInfoResponse
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? FirstName { get; set; }
    public DateTime Modified { get; set; }
}