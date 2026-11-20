using EProduct.Domain.Entities.DTO;
using EProduct.Domain.Entities.Entities;

namespace EProduct.Domain.Entities.Contracts;

/// <summary>
/// Repository Methods for Customer Repository
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Get the customer details by customer id
    /// </summary>
    /// <param name="cutomerId"><see cref="int"/> Id of the customer</param>
    /// <returns><see cref="Customer"/></returns>
    public List<Customer> GetCustomerDetailsById(int cutomerId);

    /// <summary>
    /// Get the customer and type detail by customer id
    /// </summary>
    /// <param name="cutomerId"><see cref="int"/></param>
    /// <returns><see cref="CustomerTypeDetail"/></returns>
    public CustomerTypeDetail? GetCustomerTypeDetailById(int cutomerId);
}