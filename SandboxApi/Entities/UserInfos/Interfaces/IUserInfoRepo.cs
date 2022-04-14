using SandboxApi.Core.BaseInterfaces;

namespace SandboxApi.Entities.UserInfos.Interfaces;

/// <summary>
///     UserInfo repo interface
/// </summary>
public interface IUserInfoRepo : IRepo<UserInfo>, IUserInfoProvider
{
}