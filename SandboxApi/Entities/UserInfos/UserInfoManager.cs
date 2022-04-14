using SandboxApi.Core.BaseInterfaces;
using SandboxApi.Core.BaseTypes;
using SandboxApi.Core.DIInterfaces;
using SandboxApi.Entities.UserInfos.Interfaces;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     Userinfo manager
/// </summary>
public class UserInfoManager : BaseManager<UserInfo>, IUserInfoManager, IScopedInjection
{
    /// <inheritdoc />
    public UserInfoManager(ILogger<UserInfoManager> logger, IRepo<UserInfo> repo)
        : base(logger, repo)
    {
    }
}