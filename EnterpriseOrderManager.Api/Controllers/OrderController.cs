using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseOrderManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
            
        }

        [HttpGet("get-by-id/{id:Guid}")]
        public async Task<IActionResult> GetById([FromBody] Guid id)
        {


            return Ok();
        }

    }
}
