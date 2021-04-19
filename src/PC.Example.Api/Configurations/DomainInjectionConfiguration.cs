using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PC.Example.Domain;
using PC.Example.Domain.Interfaces.Services;

namespace PC.Exemple.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    internal static class DomainInjectionConfiguration
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            return services;
        }
    }
}