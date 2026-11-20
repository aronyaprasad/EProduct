using EProduct.Domain.Entities.Contracts;
using EProduct.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace EProduct.Repository;

/// <summary>
/// Register the services related to the Repository
/// </summary>
public static class RepositoryRegistration
{
    /// <summary>
    /// Service Registration
    /// </summary>
    /// <param name="services"><see cref="IServiceContainer"/></param>
    /// <returns></returns>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}

