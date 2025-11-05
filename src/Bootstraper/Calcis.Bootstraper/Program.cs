using Calcis.Bootstraper.Components;
using Calcis.Modules.Base.Application.Queries.Handlers;
using Calcis.Shared.Infrastructure.Api;
using Calcis.Shared.Infrastructure.Modules;
using Calcis.Shared.Infrastructure.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;
using NLog;
using NLog.Web;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Calcis.Shared.Infrastructure;

var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add secret.json to the container
    builder.Configuration
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("secret.json", optional: false, reloadOnChange: true);

    // Add modules to the contrainter
    ModuleLoader.RegisterModules(builder.Services);
    builder.Services.AddSharedInfrastructure();

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

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

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddAdditionalAssemblies([.. ViewLoader.LoadViews()])
        .AddInteractiveServerRenderMode();

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