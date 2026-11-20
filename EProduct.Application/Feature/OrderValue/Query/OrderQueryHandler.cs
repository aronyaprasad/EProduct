using EProduct.Domain.Entities.Contracts;
using MediatR;

namespace EProduct.Application.Feature.OrderValue.Query;

/// <summary>
/// Handler class to process the request
/// </summary>
/// <param name="customerRepository"><see cref="ICustomerRepository"/></param>
public class OrderQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<OrderQuery, OrderQueryResponse>
{
    /// <summary>
    /// Handler for OrderQuery
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<OrderQueryResponse> Handle(OrderQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Todo - Add Logging
            var customerTypeDetail = customerRepository.GetCustomerTypeDetailById(request.CustomerId);
            if (customerTypeDetail is null)
            {
                return new OrderQueryResponse(
                        OrderId: request.OrderId,
                        CustomerId: request.CustomerId,
                        CustomerName:string.Empty,
                        DiscountPrice: 0,
                        FinalPrice: request.Amount,
                        HttpStatusCode: System.Net.HttpStatusCode.OK,
                        Message: "User is not registered. So price shown is the final amount. No discount amount" // Note - This will be in resource file for globalization
                        );
            }

            // Get the discounted amount
            var discountAmount = GetDiscountAmount(request.Amount, customerTypeDetail.Discount);
            if(discountAmount < 0)
                return new OrderQueryResponse(
                        OrderId: request.OrderId,
                        CustomerId: request.CustomerId,
                        CustomerName: customerTypeDetail.CustomerName,
                        DiscountPrice: 0,
                        FinalPrice: 0,
                        HttpStatusCode: System.Net.HttpStatusCode.UnprocessableEntity,
                        Message: $"Request can not be processed as discount value {discountAmount} is not correct." // Note - This will be in resource file for globalization
                    );

            return new OrderQueryResponse(
                        OrderId: request.OrderId,
                        CustomerId: request.CustomerId,
                        CustomerName: customerTypeDetail.CustomerName,
                        DiscountPrice: discountAmount,
                        FinalPrice: (request.Amount-discountAmount),
                        HttpStatusCode: System.Net.HttpStatusCode.OK,
                        Message: "Success" // Note - This will be in resource file for globalization
                    );

        }
        catch (Exception e)
        {
            return new OrderQueryResponse(
                OrderId: request.OrderId,
                CustomerId: request.CustomerId,
                CustomerName: string.Empty,
                DiscountPrice: 0,
                FinalPrice: 0,
                HttpStatusCode: System.Net.HttpStatusCode.InternalServerError,
                Message: e.Message
            );
        }
    }

    /// <summary>
    /// Get the discounted amount
    /// </summary>
    /// <param name="actualAmount"><see cref="decimal"/> actual amount</param>
    /// <param name="discount"><see cref="int"/>Discount </param>
    /// <param name="coupon"><see cref="int?"/>Coupon code value.</param>
    /// <returns><see cref="decimal"/>Discounted value</returns>
    private decimal GetDiscountAmount(decimal actualAmount, int discount, int? coupon=0)
    {
        return (actualAmount * (discount+ coupon ?? 0)) / 100;
    }
}

