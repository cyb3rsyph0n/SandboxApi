using SandboxApi.Core.BaseTypes;
using SandboxApi.Core.DIInterfaces;
using SandboxApi.Entities.UserInfos.Interfaces;
using SandboxApi.Entities.UserInfos.Responses;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     UserInfo transformer
/// </summary>
public class UserInfoTransformer : BaseTransformer<UserInfo, UserInfoResponse>, IUserInfoTransformer, IScopedInjection
{
    /// <inheritdoc />
    public override UserInfoResponse ToDto(UserInfo entity)
    {
        return new UserInfoResponse
        {
            Id = entity.Id,
            Created = entity.Created,
            Modified = entity.Modified,
            FirstName = entity.Name,
            EmailAddress = entity.EmailAddress
        };
    }
}