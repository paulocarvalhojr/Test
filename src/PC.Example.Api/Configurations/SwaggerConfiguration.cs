using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PC.Exemple.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    internal static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                });
            });

            return services;
        }
        
        public static IApplicationBuilder UseSwaggerSettings(this IApplicationBuilder builder)
        {
            builder.UseSwagger();

            builder.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PC Example Api");
            });

            return builder;
        }
    }
}