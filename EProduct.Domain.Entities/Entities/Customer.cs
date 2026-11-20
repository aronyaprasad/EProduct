namespace EProduct.Domain.Entities.Entities;

/// <summary>
/// Customer Entity Class
/// </summary>
public sealed class Customer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public int CustomerId { get; set; }
    
    /// <summary>
    /// Customer Full Name
    /// </summary>
    public required string CustomerName { get; set; }

    /// <summary>
    /// Email of the Customer
    /// </summary>
    public required string CustomerEmail { get; set; } 

    /// <summary>
    /// Contact Number of the Customer
    /// </summary>
    public required string ContactNumber { get; set; }

    /// <summary>
    /// FK relation to Customer Type
    /// </summary>
    public int CustomerType { get; set; }

}

