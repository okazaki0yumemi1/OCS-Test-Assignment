using Microsoft.AspNetCore.Mvc;
using OCS_Test_Assignment.Models;
using OCS_Test_Assignment.Persistence;

namespace OCS_Test_Assignment.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase, IController<Order>
    {
        private readonly OrdersDbOperations _dbOperations;
        public OrdersController(OrdersDbOperations dbOperations)
        {
            _dbOperations = dbOperations;
        }
        [HttpPost("api/orders")]
        public Task<IActionResult> Create([FromBody] Order obj)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("api/orders/{orderId}")]
        public Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("api/orders")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbOperations.GetAllAsync());
        }
        [HttpGet("api/orders/{orderId}")]
        public Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("api/orders/{orderId}")]
        public Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
