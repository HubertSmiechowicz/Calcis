using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Calcis.Shared.Infrastructure.Modules
{
    public static class ModuleLoader
    {
        private static IList<Assembly> LoadAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();

            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                .Where(x => x.Contains("Calcis.Modules.")) // tylko moduły
                .ToList();

            foreach (var file in files)
            {
                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(file);
                    assemblies.Add(AppDomain.CurrentDomain.Load(assemblyName));
                }
                catch (Exception ex) when (
                    ex is FileLoadException ||
                    ex is BadImageFormatException ||
                    ex is FileNotFoundException)
                {
                    Console.WriteLine($"[ModuleLoader] Skipping {file}: {ex.Message}");
                }
            }

            return assemblies;
        }

        public static IList<IModule> LoadModules()
        {
            return LoadAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .OrderBy(x => x.Name)
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();
        }

        /// <summary>
        /// Rejestruje wszystkie moduły aplikacji i ich kontrolery.
        /// </summary>
        public static IMvcBuilder RegisterModules(IServiceCollection services, IList<IModule> modules, IConfiguration config)
        {
            // Tworzymy wspólny builder MVC
            var mvcBuilder = services.AddControllers();

            foreach (var module in modules)
            {
                // Nowa wersja interfejsu — przekazujemy IMvcBuilder
                module.Register(services, mvcBuilder, config);
            }

            return mvcBuilder;
        }

        public static void RegisterContexts(IServiceProvider serviceProvider, IList<IModule> modules)
        {
            foreach (var module in modules)
            {
                module.RegisterContexts(serviceProvider);
            }
        }
    }
}
