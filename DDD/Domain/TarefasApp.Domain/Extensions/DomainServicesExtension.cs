using Microsoft.Extensions.DependencyInjection;
using TarefasApp.Domain.Interfaces.Services;
using TarefasApp.Domain.Services;

namespace TarefasApp.Domain.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ITarefaDomainService, TarefaDomainService>();

            return services;
        }
    }
}