using System.Reflection;
using System.Text.RegularExpressions;
using SandboxApi.Core.BaseInterfaces;
using SandboxApi.Core.DIInterfaces;
using SandboxApi.Exceptions;

namespace SandboxApi.Core.BaseTypes;

public class AppSettings : IAppSettings, ISingletonInjection
{
    private readonly IConfiguration configuration;
    private readonly ILogger<AppSettings> logger;

    /// <summary>
    ///     Default ctor
    /// </summary>
    /// <param name="configuration">Required configuration</param>
    /// <param name="logger">Required logger</param>
    public AppSettings(IConfiguration configuration, ILogger<AppSettings> logger)
    {
        this.configuration = configuration;
        this.logger = logger;

        VerifyConfig();
    }

    /// <inheritdoc />
    public string ConnectionString => GetConnectionString("ConnectionStrings:Default", null) ??
                                      throw new MissingConfigurationException($"Missing {nameof(ConnectionString)}");

    /// <inheritdoc />
    public string Schema => GetConfigSetting("ConnectionStrings:Schema", null) ??
                            throw new MissingConfigurationException($"Missing {nameof(ConnectionString)}");

    private string? GetConfigSetting(string configSetting, string? defaultValue)
    {
        var configValue = configuration[configSetting];

        return !string.IsNullOrEmpty(configValue) ? configValue : defaultValue;
    }

    private int GetConfigSetting(string configSetting, int defaultValue)
    {
        return int.Parse(GetConfigSetting(configSetting, defaultValue.ToString()) ?? "0");
    }

    private bool GetConfigSetting(string configSetting, bool defaultValue)
    {
        return bool.Parse(GetConfigSetting(configSetting, defaultValue.ToString()) ?? "false");
    }

    private string? GetConnectionString(string connectionStringName, string? defaultValue)
    {
        var regEx = new Regex(
            @"postgres:\/\/(?<userId>[a-zA-z\d]+):(?<password>[a-zA-z\d]+)@(?<host>[a-zA-z\d\-\.]+(.com)?):(?<port>[\d]+)\/(?<database>[a-zA-z\d\-]+)"
        );

        var connValue = GetConfigSetting("DATABASE_URL", null) ?? GetConfigSetting(connectionStringName, defaultValue);

        var match = regEx.Match(connValue ?? string.Empty);

        return match.Success
            ? $"User ID={match.Groups["userId"]};Password={match.Groups["password"]};Host={match.Groups["host"]};Port={match.Groups["port"]};Database={match.Groups["database"]};Pooling=true;SslMode=Prefer;Trust Server Certificate=true;"
            : connValue;
    }

    private void VerifyConfig()
    {
        var shouldThrow = false;
        var type = typeof(IAppSettings);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        logger.LogInformation("Beginning Validating AppSettings");
        foreach (var prop in props)
            try
            {
                var val = prop.GetValue(this);
                logger.LogDebug("\t{PropName}: {PropValue}", prop.Name, val);
            }
            catch (MissingConfigurationException configurationException)
            {
                shouldThrow = true;
                logger.LogCritical("{Exception}", configurationException.Message);
            }

        logger.LogInformation("Finished Validating AppSettings");

        if (shouldThrow)
            throw new MissingConfigurationException("Missing configuration settings");
    }
}