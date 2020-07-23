using System;
using Microsoft.Extensions.DependencyInjection;
using Sensa_questionnaireSystem.Logic.Helpers;

namespace Sensa_questionnaireSystem.ServiceConfigurations
{
    public static class ServiceExtension
    {
        public static void AddScopes(this IServiceCollection service)
        {
            service.AddScoped<HomeHelperFunctions>();
        }
    }
}