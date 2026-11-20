using EProduct.Domain.Entities.Entities;

namespace EProduct.Domain.Entities.DTO;

/// <summary>
/// DTO object for Customer Type Details
/// </summary>
/// <param name="CustomerId"><see cref="int"/> Customer Id</param>
/// <param name="CustomerName"><see cref="string"/> Customer Name</param>
/// <param name="CustomerType"><see cref="int"/> Customer Type</param>
/// <param name="Discount"><see cref="int"/>Discount value</param>
public record CustomerTypeDetail(
    int CustomerId,
    string CustomerName,
    int CustomerType,
    int Discount
    )
{
    
}

