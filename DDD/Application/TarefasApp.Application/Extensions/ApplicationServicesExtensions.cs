using System;
using Microsoft.Extensions.DependencyInjection;
using TarefasApp.Application.Interfaces;
using TarefasApp.Application.Services;

namespace TarefasApp.Application.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<ITarefaAppService, TarefaAppService>();

            return services;
        }
    }
}