using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application;
using SMS.Application.Shared.Common.Interfaces;
using SMS.Application.Shared.Interfaces;
using SMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.API.Injection
{
    public static class DependencyInjection
    {
        private static IServiceCollection _services;

        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            _services = services;

            _services.AddScoped<IRepository, Repository>();
            _services.AddScoped<ITestApplication, TestApplication>();
            // Clients
            //services.AddHttpClient<IAzureAuthenticationClient, AzureAuthenticationClient>(c =>
            //{
            //    c.BaseAddress = new Uri("https://login.microsoftonline.com/");
            //});

            return _services;
        }
    }
}
