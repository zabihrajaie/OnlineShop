using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Dtos;

namespace OnlineShop.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, AppSettings appSettings, Assembly startupProjectAssembly);
    }
}
