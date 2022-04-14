// ReSharper disable MemberCanBePrivate.Global

using SandboxApi.Core.BaseInterfaces;

namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base manager for all managers
/// </summary>
/// <typeparam name="TEntity">Required type manager is for</typeparam>
public abstract class BaseManager<TEntity> : IManager<TEntity> where TEntity : BaseEntity
{
    private readonly ILogger<BaseManager<TEntity>> logger;

    /// <summary>
    ///     Default ctor
    /// </summary>
    /// <param name="logger">Required logger for logging</param>
    /// <param name="repo">Required repo</param>
    protected BaseManager(ILogger<BaseManager<TEntity>> logger, IRepo<TEntity> repo)
    {
        Repo = repo;
        this.logger = logger;
    }

    /// <summary>
    ///     Repo for this manager
    /// </summary>
    protected IRepo<TEntity> Repo { get; }

    /// <inheritdoc />
    public async Task DeleteById(Guid id)
    {
        await Repo.Delete(id);
    }

    /// <inheritdoc />
    public async Task<TEntity> FindById(Guid id)
    {
        return await Repo.FindById(id);
    }

    /// <inheritdoc />
    public async Task<IList<TEntity>> ListAll()
    {
        return await Repo.ListAll();
    }
}