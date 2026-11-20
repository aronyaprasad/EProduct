using EProduct.Application.Behaviour;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EProduct.Application;

/// <summary>
/// Class for registering the services
/// </summary>
public static class ApplicationRegistration
{
    /// <summary>
    /// Register the services
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        var assembly = typeof(ApplicationRegistration).Assembly;
        // Register MediateR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);

            // Inject Validator to the midiatR pipeline pipeline, so that request validated before reaching the handler
            cfg.AddOpenBehavior(typeof(ValidatorBehaviour<,>));
        });

        // Register Fluent validation for explicit invocation
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}