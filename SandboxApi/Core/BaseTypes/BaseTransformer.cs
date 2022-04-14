using SandboxApi.Core.BaseInterfaces;

namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base transformer
/// </summary>
/// <typeparam name="TEntity">Required input entity</typeparam>
/// <typeparam name="TResponse">Required response dto</typeparam>
public abstract class BaseTransformer<TEntity, TResponse> : ITransformer<TEntity, TResponse> where TEntity : BaseEntity
{
    /// <inheritdoc />
    public abstract TResponse ToDto(TEntity entity);

    /// <inheritdoc />
    public virtual IList<TResponse> ToDtoList(IList<TEntity> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}