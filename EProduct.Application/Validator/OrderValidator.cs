using EProduct.Application.Feature.OrderValue.Query;
using FluentValidation;

namespace EProduct.Application.Validator;

/// <summary>
/// Validator for <see cref="OrderQuery"/>
/// </summary>
public sealed class OrderValidator : AbstractValidator<OrderQuery>
{
    /// <summary>
    /// Initializes the validator rule
    /// </summary>
    public OrderValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("Order ID can not be zero or less than zero."); // Note - Will be part of the resource file for globalization
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID can not be zero or less than zero."); // Note - Will be part of the resource file for globalization
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount can not be zero or less than zero."); // Note - Will be part of the resource file for globalization
    }
}

