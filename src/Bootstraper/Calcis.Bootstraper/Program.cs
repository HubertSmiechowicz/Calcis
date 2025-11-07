using Calcis.Modules.Base.Application.Queries.Handlers;
using Calcis.Shared.Infrastructure;
using Calcis.Shared.Infrastructure.Database;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using NLog;
using NLog.Web;
using System.Reflection;

var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Calcis API",
            Version = "v1",
            Description = "API zintegrowane z Keycloak"
        });

        // Konfiguracja zabezpieczenia JWT Bearer
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "WprowadŸ token JWT w formacie: **Bearer {token}**",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };

        c.AddSecurityDefinition("Bearer", securityScheme);

        // Wymagaj autoryzacji domyœlnie dla endpointów
        var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            securityScheme,
            new string[] {}
        }
    };
        c.AddSecurityRequirement(securityRequirement);

        // (opcjonalnie) automatyczne wczytanie XML z komentarzami do dokumentacji
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        if (File.Exists(xmlPath))
        {
            c.IncludeXmlComments(xmlPath);
        }
    });


    // Add secret.json to the container
    builder.Configuration
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("secret.json", optional: false, reloadOnChange: true);

    // Add modules to the container (³aduje kontrolery)
    var mvcBuilder = ModuleLoader.RegisterModules(builder.Services);
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

    builder.Services.AddSingleton<IWriteMongoClient>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return new WriteMongoClient(settings.WriteConnectionString);
    });

    builder.Services.AddSingleton<IReadMongoClient>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return new ReadMongoClient(settings.ReadConnectionString);
    });

    // Add Redis distributed caching to the container
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration["Redis:Configuration"];
        options.InstanceName = builder.Configuration["Redis:InstanceName"];
    });

    // Add Authentication with JWT Bearer
    var keycloakAuthority = builder.Configuration["Keycloak:Authority"]; // np. "http://keycloak:8080/realms/calcis"
    var keycloakClientId = builder.Configuration["Keycloak:ClientId"];

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = keycloakAuthority;
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = keycloakAuthority, // teraz pasuje do issuer w tokenie
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            RoleClaimType = "realm_access.roles" // jeœli chcesz mapowaæ role
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = ctx =>
            {
                Console.WriteLine("Auth failed: " + ctx.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = ctx =>
            {
                Console.WriteLine("Token validated for: " + ctx.Principal.Identity?.Name);
                return Task.CompletedTask;
            },
            OnChallenge = ctx =>
            {
                Console.WriteLine("Challenge: " + ctx.ErrorDescription);
                return Task.CompletedTask;
            }
        };
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

    // Middleware dla autoryzacji
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

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
