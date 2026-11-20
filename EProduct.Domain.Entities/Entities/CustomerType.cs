namespace EProduct.Domain.Entities.Entities;

/// <summary>
/// Consider this as a Lookup table which holds types of customer and associated discount value
/// </summary>
public class CustomerType
{
    /// <summary>
    /// Indicates the types of the customer
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the type
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Discount amount associated to each Type
    /// </summary>
    public int Discount {  get; set; }
}

