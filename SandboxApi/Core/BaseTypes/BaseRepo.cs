using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SandboxApi.Core.BaseInterfaces;

namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base repo for all repositories
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TMapping">Required mapping type</typeparam>
public abstract class BaseRepo<TEntity, TMapping> : DbContext, IRepo<TEntity> where TEntity : BaseEntity, new()
    where TMapping : IEntityTypeConfiguration<TEntity>, new()
{
    private readonly IAppSettings appSettings;
    private readonly ILogger<BaseRepo<TEntity, TMapping>> logger;

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="logger">Required logger for repo</param>
    /// <param name="appSettings">Required app settings</param>
    protected BaseRepo(ILogger<BaseRepo<TEntity, TMapping>> logger, IAppSettings appSettings)
    {
        this.logger = logger;
        this.appSettings = appSettings;
        Entities = base.Set<TEntity>();
    }

    /// <summary>
    ///     Entities for repo
    /// </summary>
    protected DbSet<TEntity> Entities { get; }

    /// <inheritdoc />
    public async Task Delete(Guid id)
    {
        logger.LogDebug("Deleting {EntityType} with id {Id}", typeof(TEntity).Name, id);

        var entity = await base.Set<TEntity>().FirstAsync(a => a.Id == id);
        base.Set<TEntity>().Remove(entity);
        await base.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<TEntity> FindById(Guid id)
    {
        logger.LogDebug("Finding {EntityType} with id {Id}", typeof(TEntity).Name, id);

        return await base.Set<TEntity>().FirstAsync(a => a.Id == id);
    }

    /// <inheritdoc />
    public async Task<IList<TEntity>> ListAll()
    {
        logger.LogDebug("Listing all entities for {EntityType}", typeof(TEntity).Name);

        return await base.Set<TEntity>().ToListAsync();
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        logger.LogDebug("Configuring context for {EntityType}", typeof(TEntity).Name);
        optionsBuilder.UseNpgsql(appSettings.ConnectionString);
        optionsBuilder.LogTo(s=> logger.LogInformation("{Message}", s));
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        logger.LogDebug("Configuring model for {EntityType}", typeof(TEntity).Name);

        modelBuilder.ApplyConfiguration(new TMapping());
        modelBuilder.Entity<TEntity>().ToTable(typeof(TEntity).Name, appSettings.Schema);
    }
}