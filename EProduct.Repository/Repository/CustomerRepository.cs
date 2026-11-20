using EProduct.Domain.Entities.Contracts;
using EProduct.Domain.Entities.DTO;
using EProduct.Domain.Entities.Entities;

namespace EProduct.Repository.Repository;

/// <summary>
/// Repository class to get the data from 
/// </summary>
public sealed class CustomerRepository : ICustomerRepository
{
    /// <summary>
    /// Dataset. Assuming the same stored in the database
    /// </summary>
    private List<Customer> Customers = new List<Customer> { 
        new Customer { CustomerId  = 1, CustomerName = "Mukesh", CustomerEmail = "mukesh@xyz.com", ContactNumber = "+9125631256321", CustomerType = 2},
        new Customer { CustomerId  = 2, CustomerName = "Jade", CustomerEmail = "Jade@xyz.com", ContactNumber = "+125631256322", CustomerType = 1},
        new Customer { CustomerId  = 3, CustomerName = "Neha", CustomerEmail = "neha@xyz.com", ContactNumber = "+9125631256323", CustomerType = 3},
        new Customer { CustomerId  = 4, CustomerName = "Robert", CustomerEmail = "robert@xyz.com", ContactNumber = "+125631256324", CustomerType = 4},
    };

    /// <summary>
    /// Dataset for Customer Type
    /// </summary>
    private List<CustomerType> CustomerTypes = new List<CustomerType> {
        new CustomerType { Id = 1, Name = "Regular", Discount = 5 },
        new CustomerType { Id = 2, Name = "Premium", Discount = 10 },
        new CustomerType { Id = 3, Name = "VIP", Discount = 15 },
        new CustomerType { Id = 4, Name = "VIP", Discount = -15 },
    };
    public List<Customer> GetCustomerDetailsById(int cutomerId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get the customer and type detail by customer id
    /// </summary>
    /// <param name="cutomerId"><see cref="int"/></param>
    /// <returns><see cref="CustomerTypeDetail"/></returns>
    public CustomerTypeDetail? GetCustomerTypeDetailById(int cutomerId)
    {
        var customerTypeDetail = Customers.Where(x => x.CustomerId == cutomerId).Join(
            CustomerTypes,
            customer => customer.CustomerType,
            customerType => customerType.Id,
            (customer, customerType) => new CustomerTypeDetail(
                    customer.CustomerId,
                    customer.CustomerName,
                    customerType.Id,
                    customerType.Discount
                )
            ).FirstOrDefault();
        return customerTypeDetail ?? null;
    }
}