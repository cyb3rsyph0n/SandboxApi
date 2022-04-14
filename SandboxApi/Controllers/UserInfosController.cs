using Microsoft.AspNetCore.Mvc;
using SandboxApi.Core.BaseInterfaces;
using SandboxApi.Core.BaseTypes;
using SandboxApi.Entities.UserInfos;
using SandboxApi.Entities.UserInfos.Responses;

namespace SandboxApi.Controllers;

/// <summary>
///     User info controller
/// </summary>
public class UserInfosController : BaseController<UserInfo, UserInfoResponse>
{
    /// <inheritdoc />
    public UserInfosController(
        ILogger<UserInfosController> logger,
        IManager<UserInfo> manager,
        ITransformer<UserInfo, UserInfoResponse> transformer
    )
        : base(logger, manager, transformer)
    {
    }

    /// <summary>
    ///     Delete a user info by id
    /// </summary>
    /// <param name="id">Required id to delete</param>
    [HttpDelete("{id:guid}")]
    public new async Task DeleteById(Guid id)
    {
        await base.DeleteById(id);
    }

    /// <summary>
    ///     Find a user info by id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public new async Task<UserInfoResponse> FindById(Guid id)
    {
        return await base.FindById(id);
    }
}