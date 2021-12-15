﻿using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using OnlineShop.Domain.Dtos;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Installer
{
    public class RegisterServicesUsingAutoRegisterDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, AppSettings appSettings, Assembly startupProjectAssembly)
        {
            var dataAssembly = typeof(SendType).Assembly;
            var serviceAssembly = typeof(SendType).Assembly;
            var configurationAssembly = Assembly.GetExecutingAssembly();
            var assembliesToScan = new[] { dataAssembly, serviceAssembly, configurationAssembly };

            #region Generic Type Dependencies
            //services.AddScoped(typeof(IRepository<IEntity>), typeof(Repository<IEntity, DocumentDbContext>));
            #endregion

            #region Scoped Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(IScopedDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
            #endregion

            #region Singleton Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);
            #endregion

            #region Transient Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(ITransientDependency)))
                .AsPublicImplementedInterfaces(); // Default is Transient
            #endregion

            #region Register DIs By Name
            services.RegisterAssemblyPublicNonGenericClasses(dataAssembly)
                .Where(c => c.Name.EndsWith("Repository")
                            && !c.GetInterfaces().Contains(typeof(ITransientDependency))
                            && !c.GetInterfaces().Contains(typeof(IScopedDependency))
                            && !c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(serviceAssembly)
                .Where(c => c.Name.EndsWith("Service")
                            && !c.GetInterfaces().Contains(typeof(ITransientDependency))
                            && !c.GetInterfaces().Contains(typeof(IScopedDependency))
                            && !c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces();

            #endregion
        }
    }
}
