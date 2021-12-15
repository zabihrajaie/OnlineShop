using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Dtos;
using OnlineShop.Repository.EntityFramework.DbContext;

namespace OnlineShop.Installer
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, AppSettings settings, Assembly startupProjectAssembly)
        {
            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(settings.ConnectionString.OnlineShopConnectionString));
        }
    }
}