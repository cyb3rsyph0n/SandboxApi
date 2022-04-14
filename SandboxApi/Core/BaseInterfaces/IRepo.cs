using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Core.BaseInterfaces;

/// <summary>
///     Handles all write operations for an entity
/// </summary>
/// <typeparam name="TEntity">Required type repo is for</typeparam>
public interface IRepo<TEntity> : IProvider<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Delete entity by id
    /// </summary>
    /// <param name="id">Required id to delete</param>
    /// <returns></returns>
    Task Delete(Guid id);
}