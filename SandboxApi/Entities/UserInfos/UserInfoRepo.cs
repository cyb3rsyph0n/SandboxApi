using Microsoft.EntityFrameworkCore;
using SandboxApi.Core.BaseInterfaces;
using SandboxApi.Core.BaseTypes;
using SandboxApi.Core.DIInterfaces;
using SandboxApi.Entities.UserInfos.Interfaces;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     Userinfo repo
/// </summary>
public class UserInfoRepo : BaseRepo<UserInfo, UserInfoMapping>, IUserInfoRepo, IScopedInjection
{
    /// <inheritdoc />
    public UserInfoRepo(ILogger<UserInfoRepo> logger, IAppSettings appSettings)
        : base(logger, appSettings)
    {
    }

    /// <inheritdoc />
    public async Task<UserInfo?> TryFindByEmailAddress(string emailAddress)
    {
        return await Entities.FirstOrDefaultAsync(a => a.EmailAddress == emailAddress);
    }
}