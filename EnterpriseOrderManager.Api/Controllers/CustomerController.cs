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

        //[HttpGet]
        //public async Task<IActionResult> NumberToStr(int number)
        //{
        //    string value = number.ToString("D5");
        //    Console.WriteLine(value);
        //    return Ok(value);
        //}

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
                return NotFound();
            }
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> Add(CustomerCreateRequest request, CancellationToken ct)
        {
            var createModel = request.ToModel();
            var newCustomerDomain = await _service.AddAsync(createModel, ct);
            return Ok("Customer created"); // I'll refine it later, will add CreatedAction
        }
    }
}
