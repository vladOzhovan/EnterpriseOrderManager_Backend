using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Api.Mappers;
using EnterpriseOrderManager.Application.Contracts;
using EnterpriseOrderManager.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseOrderManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns a filtered/sorted list of customers.
        /// </summary>
        /// <param name="dto">Query parameters for filtering, paging and sorting.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A collection of <see cref="CustomerResponseDto"/>.</returns>
        /// <response code="200">Customers returned successfully.</response>
        /// <response code="400">Invalid query parameters(e.g. unsupported sort field)</response>
        [HttpGet("get-all-customers")]
        public async Task<IActionResult> GetAll([FromQuery] CustomerQueryDto dto, CancellationToken ct)
        {
            var sortResult = CustomerSortFieldParser.Parse(dto.SortBy);

            if (!sortResult.Succeeded)
                return BadRequest(sortResult.Error);

            CustomerQuery query = dto.ToQuery(sortResult.Value);
            var customersDomain = await _service.GetAllAsync(query, ct);
            var responseDto = customersDomain.Select(c => c.ToResponseDto());
            return Ok(responseDto);
        }

        /// <summary>
        /// Returns a customer by id.
        /// </summary>
        /// <param name="id">Customer identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="CustomerResponseDto"/> if found; otherwise a 404 response.</returns>
        /// <response code="200">Customer found and returned.</response>
        /// <response code="400">Customer with the specific id not found.</response>
        [HttpGet("get-by-id/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            try
            {
                var customer = await _service.GetByIdAsync(id, ct);
                return Ok(customer.ToResponseDto());
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Not found",
                    Detail = "Customer not found."
                });
            }
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="request">Customer data for creation.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>
        /// A success response.
        /// </returns>
        [HttpPost("add-customer")]
        public async Task<IActionResult> Add(CustomerCreateRequest request, CancellationToken ct)
        {
            var createModel = request.ToModel();
            var newCustomerDomain = await _service.AddAsync(createModel, ct);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = newCustomerDomain.Id },
                value: newCustomerDomain.ToResponseDto()
            );
        }
    }
}
