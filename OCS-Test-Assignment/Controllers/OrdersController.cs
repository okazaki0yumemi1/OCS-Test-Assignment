using Microsoft.AspNetCore.Mvc;
using OCS_Test_Assignment.Models;

namespace OCS_Test_Assignment.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase, IController<Order>
    {
        //private readonly OrdersDbOperations _dbOperations;
        //public OrdersController(OrdersDbOperations dbOperations)
        //{
        //    _dbOperations = dbOperations;
        //}
        [HttpPost("api/orders")]
        public Task<IActionResult> Create(Order obj)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("api/orders")]
        public Task<IActionResult> Delete(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("api/orders")]
        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
        [HttpGet("api/orders")]
        public Task<IActionResult> GetByID(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("api/orders")]
        public Task<IActionResult> Update(int Id, Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
