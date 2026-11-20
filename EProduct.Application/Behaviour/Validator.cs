using FluentValidation;
using MediatR;
using System.Collections;

namespace EProduct.Application.Behaviour;

/// <summary>
/// Inject validtor to the MediatR pipeline
/// </summary>
/// <typeparam name="TRequest"><see cref="{TRequest}"/></typeparam>
/// <typeparam name="TResponse"><see cref="{TResponse}"/></typeparam>
/// <param name="validators"><see cref="IEnumerable{T}"/></param>
public class ValidatorBehaviour<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var results = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);

        return await next();
    }
}