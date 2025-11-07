using Calcis.Modules.Base.Application.Queries.Handlers;
using Calcis.Shared.Infrastructure;
using Calcis.Shared.Infrastructure.Database;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NLog;
using NLog.Web;
using System.Reflection;

var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add swagger to app
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add secret.json to the container
    builder.Configuration
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("secret.json", optional: false, reloadOnChange: true);

    // Add modules to the container
    ModuleLoader.RegisterModules(builder.Services);
    builder.Services.AddSharedInfrastructure();

    // Add Nlog to the container
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add MediatR to the container
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(HelloHandler))
        ));

    // Add MongoDB to the container
    builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
    builder.Services.AddSingleton<IMongoClient>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return new MongoClient(settings.ConnectionString);
    });

    // Add Redis distributed caching to the container
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration["Redis:Configuration"];
        options.InstanceName = builder.Configuration["Redis:InstanceName"];
    });

    var app = builder.Build();

    // Add swagger UI in development enviroment
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    // Map Controllers (API)
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
