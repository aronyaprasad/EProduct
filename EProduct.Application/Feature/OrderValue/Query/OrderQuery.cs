using MediatR;

namespace EProduct.Application.Feature.OrderValue.Query;

/// <summary>
/// Record for Order
/// Note - Record is used as there is no other operation or additional logic is needed. Otherwise we can go for class
/// </summary>
/// <param name="OrderId"><see cref="int">Order Id that user selected</see></param>
/// <param name="CustomerId"><see cref="int">User Id</see></param>
/// <param name="Amount"><see cref="decimal">Displayed value or value without discuont</see></param>
public record OrderQuery(
    int OrderId,
    int CustomerId,
    decimal Amount
    ) : IRequest<OrderQueryResponse>
{
}

