using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Core.BaseInterfaces;

/// <summary>
///     The interface for an entity transformer
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TDto">Required default dto return type</typeparam>
public interface ITransformer<TEntity, TDto> where TEntity : BaseEntity
{
    /// <summary>
    ///     Cast entity to dto
    /// </summary>
    /// <param name="entity">Required entity to cast</param>
    /// <returns></returns>
    TDto ToDto(TEntity entity);

    /// <summary>
    ///     Cast list of entities to list of dtos
    /// </summary>
    /// <param name="entities">Required list of entities</param>
    /// <returns></returns>
    IList<TDto> ToDtoList(IList<TEntity> entities);
}