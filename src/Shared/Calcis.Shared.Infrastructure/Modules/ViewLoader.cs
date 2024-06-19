using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Modules
{
    public class ViewLoader
    {
        public static IList<Assembly> LoadViews()
        {
            var assemblies = new List<Assembly>();

            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    if (ContainsIViewImplementation(assembly))
                    {
                        assemblies.Add(assembly);
                    }
                }
                catch (Exception ex) when (ex is FileLoadException || ex is BadImageFormatException || ex is FileNotFoundException)
                {
                    Console.WriteLine($"Error loading assembly: {file}. Exception: {ex.Message}");
                }
            }

            return assemblies;
        }

        private static bool ContainsIViewImplementation(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes().Any(type => typeof(IView).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.WriteLine($"ReflectionTypeLoadException in assembly: {assembly.FullName}. Exception: {ex.Message}");
                return false;
            }
        }
    }
}
