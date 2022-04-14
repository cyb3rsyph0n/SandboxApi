#pragma warning disable CS0649 // Fields are given values during persistence
namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base fields for all entities
/// </summary>
public abstract class BaseEntity
{
    private readonly DateTime created;
    private readonly Guid id;
    private readonly DateTime modified;

    /// <summary>
    ///     Required for EF
    /// </summary>
    internal BaseEntity()
    {
    }

    /// <summary>
    ///     Entity Id
    /// </summary>
    public Guid Id => id;

    /// <summary>
    ///     Entity Created Date
    /// </summary>
    public DateTime Created => created;

    /// <summary>
    ///     Entity Modified Date
    /// </summary>
    public DateTime Modified => modified;
}