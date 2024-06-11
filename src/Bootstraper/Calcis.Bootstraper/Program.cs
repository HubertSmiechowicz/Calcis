using Calcis.Modules.Base.Application.Queries.Handlers;
using Calcis.Shared.Infrastructure.Api;
using Calcis.Shared.Infrastructure.Modules;
using Calcis.Shared.Infrastructure.Database;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;
using NLog;
using NLog.Web;
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
    builder.Services.AddControllers()
        .ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });

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


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calcis API", Version = "v1" });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

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