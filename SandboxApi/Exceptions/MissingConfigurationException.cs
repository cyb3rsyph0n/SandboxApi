using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Exceptions;

/// <summary>
///     Used when a missing config value is present during config verification
/// </summary>
public class MissingConfigurationException : BaseException
{
    /// <inheritdoc />
    public MissingConfigurationException(string message)
        : base(message)
    {
    }
}