using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SandboxApi.Core.Extensions;

/// <summary>
///     Extensions for EntityTypeBuilderExtensions
/// </summary>
public static class EntityTypeBuilderExtensions
{
    /// <summary>
    ///     Removes all public properties from the entity type builder for the given entity
    /// </summary>
    /// <param name="b">Required builder</param>
    /// <typeparam name="TEntity">Required type to remove properties for</typeparam>
    public static void RemoveALlProperties<TEntity>(this EntityTypeBuilder<TEntity> b) where TEntity : class
    {
        foreach (var propertyInfo in typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            b.Ignore(propertyInfo.Name);
    }
}