using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     UserInfo entity
/// </summary>
public class UserInfo : BaseEntity
{
    private readonly string emailAddress = null!;
    private readonly string? name;
    private readonly string password = null!;

    /// <summary>
    ///     Required for EF
    /// </summary>
    public UserInfo(string emailAddress, string password, string? name)
    {
        this.emailAddress = emailAddress;
        this.name = name;
        this.password = password;
    }

    /// <summary>
    ///     Required for EF
    /// </summary>
    [Obsolete("For EF only")]
    public UserInfo()
    {
    }

    /// <summary>
    ///     Users email address
    /// </summary>
    public string EmailAddress => emailAddress;

    /// <summary>
    ///     Users first name
    /// </summary>
    public string? Name => name;

    /// <summary>
    ///     Users password
    /// </summary>
    public string Password => password;

    /// <summary>
    ///     This is to test properties aren't mapped by default
    /// </summary>
    public string SomeUnMappedProperty { get; set; }
}