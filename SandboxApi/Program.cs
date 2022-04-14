using SandboxApi.Core.DIInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Clean method of injection for all types in this project
builder.Services.Scan(
    scan => scan.FromAssemblyOf<IAssemblyMarker>()
        .AddClasses(c => c.AssignableTo<ITransientInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Transient)
        .AddClasses(c => c.AssignableTo<IScopedInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Scoped)
        .AddClasses(c => c.AssignableTo<ISingletonInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Singleton)
);

// not so clean method of injection
// builder.Services.AddTransient<IUserInfoManager, UserInfoManager>(); // By Interface
// builder.Services.AddTransient<UserInfoManager, UserInfoManager>();  // By Class
// builder.Services.AddTransient<IUserInfoTransformer, UserInfoTransformer>(); // By Interface
// builder.Services.AddTransient<UserInfoTransformer, UserInfoTransformer>();  // By Class

// this would repeat for every single type needed for dependency injection

// Add configuration for Appsettings
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();