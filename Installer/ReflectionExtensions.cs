using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Dtos;

namespace OnlineShop.Installer
{
    public static class ReflectionExtensions
    {
        public static void InstallServicesInAssemblies(this IServiceCollection services, AppSettings appSettings)
        {
            var startupProjectAssembly = Assembly.GetCallingAssembly();
            var assemblies = new[] { startupProjectAssembly, Assembly.GetExecutingAssembly() };
            var installers = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(IInstaller).IsAssignableFrom(c))
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(i => i.InstallServices(services, appSettings, startupProjectAssembly));
        }
    }
}
