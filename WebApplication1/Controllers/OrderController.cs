using Asp.Versioning;
using EProduct.Application.Feature.OrderValue.Query;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1.Controllers;

/// <summary>
/// Controller for Product Related operations
/// </summary>
/// <param name="mediator"><see cref="IMediator"/></param>
[ApiController]
[ApiVersion("1.0")]
[Route("[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    // Use of primary constrcuor as there is oo other operation will be done in the explicit declaration of the constructor

    /// <summary>
    /// End Point to get the final value of the product
    /// Note : Assumed that loggedIn user is registered.
    /// </summary>
    /// <param name="customerId"><see cref="int"/>LoggedIn Customer Id</param>
    /// <param name="id"><see cref="int"/>Id of the Order</param>
    /// <param name="amount"><see cref="decimal"/>Amount of the order</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpGet("{customerId}/{id}/value")]
    [ProducesResponseType(typeof(OrderQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderQueryResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(OrderQueryResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProductValueAsync(int customerId, int id, [FromQuery] decimal amount,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await mediator.Send(new EProduct.Application.Feature.OrderValue.Query.OrderQuery(id, customerId, amount));

            return response.HttpStatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.UnprocessableEntity => UnprocessableEntity(response),
                _ => Problem(
                    detail: response.Message,
                    statusCode: (int)response.HttpStatusCode
                )
            };
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

