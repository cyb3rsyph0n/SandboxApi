using SandboxApi.Core.BaseInterfaces;

namespace SandboxApi.Entities.UserInfos.Interfaces;

/// <summary>
///     UserInfo provider interface
/// </summary>
public interface IUserInfoProvider : IProvider<UserInfo>
{
    /// <summary>
    ///     Finds a user info by the specified email address
    /// </summary>
    /// <param name="emailAddress">Required email address to search for</param>
    /// <returns></returns>
    Task<UserInfo?> TryFindByEmailAddress(string emailAddress);
}