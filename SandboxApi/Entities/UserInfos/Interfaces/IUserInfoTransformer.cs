using SandboxApi.Core.BaseInterfaces;
using SandboxApi.Entities.UserInfos.Responses;

namespace SandboxApi.Entities.UserInfos.Interfaces;

/// <summary>
///     UserInfo transformer interface
/// </summary>
public interface IUserInfoTransformer : ITransformer<UserInfo, UserInfoResponse>
{
}