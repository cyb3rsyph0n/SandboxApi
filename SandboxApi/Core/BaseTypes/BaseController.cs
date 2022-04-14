using Microsoft.AspNetCore.Mvc;
using SandboxApi.Core.BaseInterfaces;

// ReSharper disable MemberCanBePrivate.Global

namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base controller class for all entities
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TResponse">Required response type</typeparam>
[Controller]
[Route("api/[controller]/")]
public abstract class BaseController<TEntity, TResponse> where TEntity : BaseEntity
{
    /// <summary>
    ///     Default ctor
    /// </summary>
    /// <param name="logger">Required logger</param>
    /// <param name="manager">Required manager</param>
    /// <param name="transformer">Required transformer1</param>
    protected BaseController(
        ILogger<BaseController<TEntity, TResponse>> logger,
        IManager<TEntity> manager,
        ITransformer<TEntity, TResponse> transformer
    )
    {
        Logger = logger;
        Manager = manager;
        Transformer = transformer;
    }

    /// <summary>
    ///     Logger for the controller
    /// </summary>
    protected ILogger<BaseController<TEntity, TResponse>> Logger { get; }

    /// <summary>
    ///     Manager for the controller
    /// </summary>
    protected IManager<TEntity> Manager { get; }

    /// <summary>
    ///     Transformer for the controller
    /// </summary>
    protected ITransformer<TEntity, TResponse> Transformer { get; }

    /// <summary>
    ///     Delete an entity by id
    /// </summary>
    /// <param name="id">Required entity id to delete</param>
    protected async Task DeleteById(Guid id)
    {
        await Manager.DeleteById(id);
    }

    /// <summary>
    ///     Find entity by id
    /// </summary>
    /// <param name="id">Required entity id to find</param>
    /// <returns></returns>
    protected async Task<TResponse> FindById(Guid id)
    {
        var entity = await Manager.FindById(id);
        return Transformer.ToDto(entity);
    }

    /// <summary>
    ///     List all entities for a given type
    /// </summary>
    /// <returns></returns>
    protected async Task<IList<TResponse>> ListAll()
    {
        return Transformer.ToDtoList(await Manager.ListAll());
    }
}