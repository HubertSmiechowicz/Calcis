using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                .ToList();

            foreach (var file in files)
            {
                if (!file.Contains("Calcis.Modules."))
                {
                    continue;
                }

                var moduleName = file.Split("Calcis.Modules.")[1].Split(".")[0].ToLowerInvariant();

                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(file);
                    assemblies.Add(AppDomain.CurrentDomain.Load(assemblyName));
                }
                catch (FileLoadException)
                {
                    Console.WriteLine($"Error loading assembly: {file}");
                }
                catch (BadImageFormatException)
                {
                    Console.WriteLine($"Invalid assembly format: {file}");
                }
                catch (FileNotFoundException)
                {

                    Console.WriteLine($"File not found: {file}");
                }
            }

            return assemblies;
        }

        private static IList<IModule> LoadModules()
        => LoadAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();


        public static void RegisterModules(IServiceCollection service)
        {
            var modules = LoadModules();

            foreach (var module in modules)
            {
                module.Register(service);
            }
        }
    }
}
