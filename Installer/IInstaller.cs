using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Dtos;

namespace OnlineShop.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, AppSettings appSettings, Assembly startupProjectAssembly);
    }
}
