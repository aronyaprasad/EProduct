using EProduct.Domain.Entities.Entities;

namespace EProduct.Application.Contract.Entities;

public interface ICustomerRepository
{
    public List<Customer> GetCustomerDetailsById(int cutomerId);
}

