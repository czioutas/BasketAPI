using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketAPI
{
    public static class StartupExtensions
    {
        public static void AutoDiscover(IServiceCollection services, IConfiguration configuration)
        {
            SetupRepositories(services);
            SetupServices(services);
        }

        private static void SetupServices(IServiceCollection services)
        {
            IEnumerable<Type> allServices = Assembly.GetEntryAssembly().GetTypes()
                .Where(a => a.GetTypeInfo().IsClass &&
                    a.Namespace != null &&
                    a.Namespace.Contains("BasketAPI.Services") &&
                    a.Name.EndsWith("Service")
                );          
            
            foreach(Type service in allServices)
            {
                if (service.GetInterfaces().Count() > 0) {
                    services.AddScoped(service.GetInterfaces().First(), service);
                } else {
                    services.AddScoped(service);
                }
            }
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            IEnumerable<Type> allRepositores = Assembly.GetEntryAssembly().GetTypes()
                .Where(a => a.GetTypeInfo().IsClass &&
                    a.Namespace != null &&
                    a.Namespace.Contains("BasketAPI.Repositories") &&
                    a.Name.EndsWith("Repository")
                );          
            
            foreach(Type repository in allRepositores)
            {
                services.AddScoped(repository.GetInterfaces().Where(i => !i.Name.Contains("IBaseRepository")).First(), repository);
            }
        }
    }
}