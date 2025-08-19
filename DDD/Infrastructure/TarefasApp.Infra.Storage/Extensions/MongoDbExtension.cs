using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TarefasApp.Infra.Storage.Settings;
using TarefasApp.Infra.Storage.Persistence;
using TarefasApp.Infra.Storage.Contexts;

namespace TarefasApp.Infra.Storage.Extensions
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongodbSettigs = new MongoDbSettings();
            new ConfigureFromConfigurationOptions<MongoDbSettings>(configuration.GetSection("MongoDB"))
                .Configure(mongodbSettigs);

            services.AddSingleton(mongodbSettigs);
            services.AddSingleton<MongoDBContext>();
            services.AddTransient<TarefaPersistence>();

            return services;
        }
    }
}