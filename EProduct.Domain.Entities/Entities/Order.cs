namespace EProduct.Domain.Entities.Entities;

/// <summary>
/// Order Entity
/// Note - For future use once the order is placed assuming Customer is just finalizing the price
/// </summary>
public class Order
{
    /// <summary>
    /// Primary Key - Order Id
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Custmer Id
    /// </summary>
    public int CustomerId { get; set; }
}

