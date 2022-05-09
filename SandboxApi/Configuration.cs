using System.Reflection;

namespace SandboxApi;

/// <summary>
///     Static class for loading configurations per environment
/// </summary>
public static class Configuration
{
    /// <summary>
    ///     Loads proper environment configuration
    /// </summary>
    /// <returns></returns>
    public static IConfiguration LoadConfiguration(string? environmentOverride = null)
    {
        var fileName = Assembly.GetExecutingAssembly()!.Location;

        var fileInfo = new FileInfo(fileName);
        var environment = environmentOverride ??
                          Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var configuration = new ConfigurationBuilder().SetBasePath(fileInfo.Directory?.FullName)
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{environment}.json", false)
            .AddJsonFile("appsettings.Local.json", true)
            .AddEnvironmentVariables()
            .Build();
        return configuration;
    }
}