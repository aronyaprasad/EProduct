using System.Net;

namespace EProduct.Application.Feature.OrderValue.Query;

/// <summary>
/// Response Object
/// Note - Record is used as there is no other operation or additional logic is needed. Otherwise we can go for class
/// </summary>
/// <param name="OrderId"><see cref="int">Order Id that user selected</see></param>
/// <param name="CustomerId"><see cref="int">User Id</see></param>
/// <param name="CustomerName"><see cref="string"/>Customer Name </param>
/// <param name="DiscountPrice"><see cref="decimal">Discounted amount</see></param>
/// <param name="FinalPrice"><see cref="decimal">Final price after the discount</see></param>
/// <param name="HttpStatusCode"><see cref="HttpStatusCode">Status of the request</see></param>
/// <param name="Message"><see cref="string">Generic Message</see></param>
public record OrderQueryResponse(
    int OrderId,
    int CustomerId,
    string CustomerName,
    decimal DiscountPrice,
    decimal FinalPrice,
    HttpStatusCode HttpStatusCode,
    string Message)
{

}

