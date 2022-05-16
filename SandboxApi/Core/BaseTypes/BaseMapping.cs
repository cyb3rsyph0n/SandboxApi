using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base mapping class to ignore all properties by default
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class BaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{
    /// <inheritdoc />
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        foreach (var propertyInfo in typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            builder.Ignore(propertyInfo.Name);
    }
}