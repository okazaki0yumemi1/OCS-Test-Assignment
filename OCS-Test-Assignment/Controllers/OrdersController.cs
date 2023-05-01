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
        public async Task<IActionResult> Create([FromBody] Order obj)
        {
            if (obj.Lines.Count() == 0) return BadRequest("A problem occured in parsing \"lines\" in payload.");
            if (!Guid.TryParse(obj.Id.ToString(), out Guid result)) return BadRequest("Unable to parse Guid.");
            var newOrder = await _dbOperations.GetByIDAsync(result);
            if (newOrder != null) return Conflict("Order with given Id already exists.");
            else
            {
                //Checking if there are any incorrect lines in the given payload:
                foreach (var line in obj.Lines) 
                {
                    if (line.IsValid() == false)
                        return BadRequest($"Incorrect data in \"lines\". \n id:{line.Id.ToString()}, qty:{line.Qty.ToString()}"); 
                };
                var newObj = new Order(obj.Id.ToString(), obj.Lines);
                //I could just use (newOrder.DataIsValid() == true), but that is extra work for CPU and will not give error details:
                /*
                var newObj = new Order(obj.id, obj.lines);
                if (newObj.DataIsValid() == false) return BadRequest("Incorrect data in payload.");
                */
                if (await _dbOperations.CreateAsync(newObj) == true)
                {
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    var fullUrl = baseUrl + $"/api/orders/{newObj.Id.ToString()}";
                    return Created(fullUrl, newObj);
                }
                else throw new ApplicationException("Error occured in writing new Order obj to database: no orders written to database");
            }
        }
        [HttpDelete("api/orders/{orderId}")]
        public async Task<IActionResult> Delete([FromRoute] string orderId)
        {
            if (!Guid.TryParse(orderId, out Guid result)) return BadRequest("Unable to parse Guid.");
            var deleted = await _dbOperations.DeleteAsync(result);
            if (deleted) return Ok();
            else return NotFound();
        }
        [HttpGet("api/orders")]
        public async Task<IActionResult> GetAll()
        {
            //I could check for empty list and return 204 status code in that case,
            //but 200 status code and empty list is fine too, I guess.
            return Ok(await _dbOperations.GetAllAsync());
        }
        [HttpGet("api/orders/{orderId}")]
        public async Task<IActionResult> GetByID([FromRoute] string orderId)
        {
            if (!Guid.TryParse(orderId, out Guid result)) return BadRequest("Unable to parse Guid.");
            var order = await _dbOperations.GetByIDAsync(result);
            if (order == null) return NotFound();
            return Ok(order);
        }
        [HttpPut("api/orders/{orderId}")]
        public async Task<IActionResult> Update([FromRoute] string orderId, [FromBody] Order obj)
        {
            if (!Guid.TryParse(orderId, out Guid result)) return BadRequest("Unable to parse Guid.");
            var oldOrder = await _dbOperations.GetByIDAsync(result);
            if (oldOrder == null) return NotFound();
            if (oldOrder.CanBeUpdated() != true) return Forbid();
            if (obj.GetStatus() != null)
            {
                //The main idea is that it will check if status is valid first,
                //then overwrite status with different value or with, well, same value:
                oldOrder.ChangeStatus(obj.GetStatus());
                //PUT order and PATCH are different though, the line above should be changed if PUT will be changed to PATCH.
            }
            if (obj.Lines is null)
            {
                _dbOperations.UpdateAsync(oldOrder);
                return Ok(oldOrder);
            }
            if (obj.Lines.Count() != 0)
            {
                foreach (var line in obj.Lines)
                {
                    if (line.IsValid() == false) return BadRequest("Incorrect data in \"lines\".");
                }
            }
            oldOrder.Lines = obj.Lines;
            _dbOperations.UpdateAsync(oldOrder);
            return Ok(oldOrder);
        }
    }
}
