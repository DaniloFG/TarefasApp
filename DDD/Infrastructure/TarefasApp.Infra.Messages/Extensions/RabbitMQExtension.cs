using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TarefasApp.Infra.Messages.Consumers;
using TarefasApp.Infra.Messages.Producers;
using TarefasApp.Infra.Messages.Services;
using TarefasApp.Infra.Messages.Settings;

namespace TarefasApp.Infra.Messages.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQSettings = new RabbitMQSettings();

            new ConfigureFromConfigurationOptions<RabbitMQSettings>(configuration.GetSection("RabbitMQ"))
                .Configure(rabbitMQSettings);

            var emailSettings = new EmailSettings();

            new ConfigureFromConfigurationOptions<EmailSettings>(configuration.GetSection("Mail"))
                .Configure(emailSettings);

            services.AddSingleton(rabbitMQSettings);
            services.AddTransient<MessageProducer>();
            services.AddSingleton(emailSettings);
            services.AddHostedService<MessageConsumer>();
            services.AddTransient<EmailService>();

            return services;
        }
    }
}