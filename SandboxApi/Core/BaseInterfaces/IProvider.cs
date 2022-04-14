using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Core.BaseInterfaces;

/// <summary>
///     Handles all read operations for a given entity.
/// </summary>
/// <typeparam name="TEntity">Required type provider is for</typeparam>
public interface IProvider<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Find an entity by its id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    Task<TEntity> FindById(Guid id);

    /// <summary>
    ///     List all entities for the providers type
    /// </summary>
    /// <returns></returns>
    Task<IList<TEntity>> ListAll();
}