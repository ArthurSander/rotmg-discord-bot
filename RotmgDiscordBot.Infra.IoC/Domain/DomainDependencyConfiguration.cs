using Microsoft.Extensions.DependencyInjection;
using RotmgDiscordBot.Domain.Teste;

namespace RotmgDiscordBot.Infra.IoC.Domain
{
    public static class DomainDependencyConfiguration
    {
        public static IServiceCollection ConfigureDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITeste, DefaultTeste>();
            return services;
        }
    }
}
