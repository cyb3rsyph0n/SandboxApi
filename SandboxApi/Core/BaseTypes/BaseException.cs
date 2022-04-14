namespace SandboxApi.Core.BaseTypes;

/// <summary>
///     Base exception for catching internally so we know we threw and not an external library
/// </summary>
public abstract class BaseException : Exception
{
    /// <inheritdoc />
    protected BaseException(string message)
        : base(message)
    {
    }
}