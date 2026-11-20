using EProduct.Domain.Entities.Entities;
namespace EProduct.Application.Contract.Entities;

/// <summary>
/// Repository Interface for Order
/// </summary>
public interface IOrderRepository
{
    public Order GetOrderById(int orderId);
}

