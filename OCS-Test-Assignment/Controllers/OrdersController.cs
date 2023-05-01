﻿using Microsoft.AspNetCore.Mvc;
using OCS_Test_Assignment.Models;
using OCS_Test_Assignment.Persistence;
using System.Net;

namespace OCS_Test_Assignment.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase, IController<OrderDTO>
    {
        private readonly OrdersDbOperations _dbOperations;
        public OrdersController(OrdersDbOperations dbOperations)
        {
            _dbOperations = dbOperations;
        }
        [HttpPost("api/orders")]
        public async Task<IActionResult> Create([FromBody] OrderDTO obj)
        {
            if (obj.lines.Count() == 0) return BadRequest("A problem occured in parsing \"lines\" in payload.");
            if (!Guid.TryParse(obj.id, out Guid result)) return BadRequest("Unable to parse Guid.");
            var newOrder = await this.GetByID(obj.id);
            if (newOrder != null) return Conflict("Order with given Id already exists.");
            else
            {
                //Checking if there are any incorrect lines in the given payload:
                foreach (var line in obj.lines) 
                {
                    if (line.IsValid() == false)
                        return BadRequest($"Incorrect data in \"lines\". \n id:{line.detailsId.ToString()}, qty:{line.quantity.ToString()}"); 
                };
                var newObj = new Order(obj.id, obj.lines);
                //I could just use (newOrder.DataIsValid() == true), but that is extra work for CPU and will not give error details:
                /*
                var newObj = new Order(obj.id, obj.lines);
                if (newObj.DataIsValid() == false) return BadRequest("Incorrect data in payload.");
                */
                if (await _dbOperations.CreateAsync(newObj) == true)
                {
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    var fullUrl = baseUrl + $"/api/orders/{obj.id}";
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
        public async Task<IActionResult> Update([FromRoute] string orderId, [FromBody] OrderDTO obj)
        {
            if (!Guid.TryParse(orderId, out Guid result)) return BadRequest("Unable to parse Guid.");
            var oldOrder = await _dbOperations.GetByIDAsync(result);
            if (oldOrder == null) return NotFound();
            if (oldOrder.CanBeUpdated() != true) return Forbid();
            if (obj.status != null)
            {
                //The main idea is that it will check if status is valid first,
                //then overwrite status with different value or with, well, same value:
                oldOrder.ChangeStatus(obj.status);
                //PUT order and PATCH are different though, the line above should be changed if PUT will be changed to PATCH.
            }
            if (obj.lines.Count() != 0)
            {
                foreach (var line in obj.lines)
                {
                    oldOrder.AddOrUpdateLine(line);
                }
            }
            return Ok(oldOrder);
        }
    }
}
