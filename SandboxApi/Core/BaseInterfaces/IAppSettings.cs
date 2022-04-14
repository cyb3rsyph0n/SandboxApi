namespace SandboxApi.Core.BaseInterfaces;

/// <summary>
///     App settings interface
/// </summary>
public interface IAppSettings
{
    /// <summary>
    ///     Database connection string
    /// </summary>
    string ConnectionString { get; }

    /// <summary>
    ///     Database schema name
    /// </summary>
    string Schema { get; }
}