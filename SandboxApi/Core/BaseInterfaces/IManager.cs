using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Core.BaseInterfaces;

/// <summary>
///     Manager interface
/// </summary>
/// <typeparam name="TEntity">Required type of manager</typeparam>
public interface IManager<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Delete entity by id
    /// </summary>
    /// <param name="id">Required entity id</param>
    /// <returns></returns>
    Task DeleteById(Guid id);

    /// <summary>
    ///     Find entity by id
    /// </summary>
    /// <param name="id">Required id</param>
    /// <typeparam name="TEntity">Required type to find</typeparam>
    /// <returns></returns>
    Task<TEntity> FindById(Guid id);

    /// <summary>
    ///     List all entities of a given type
    /// </summary>
    /// <returns></returns>
    Task<IList<TEntity>> ListAll();
}