using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using OCS_Test_Assignment.Models;
using System.Collections.Immutable;
using System.Net;

namespace OCS_Test_Assignment.Persistence
{
    public class OrdersDbOperations : IDbOperations<Order>
    {
        private readonly DatabaseContext _dbContext;
        public OrdersDbOperations(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateAsync(Order obj)
        {
            await _dbContext.Orders.AddAsync(obj);
            var createdOrders = await _dbContext.SaveChangesAsync();
            return (createdOrders > 0);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetByIDAsync(Guid Id)
        {
            var order = await _dbContext.Orders.FindAsync(Id); //SingleOrDefaultAsync(x => x.GetOrderGuid() == Id);
            return order;
        }

        public async Task<bool> UpdateAsync(Order obj)
        {
            _dbContext.Orders.Update(obj);
            var updatedOrders = await _dbContext.SaveChangesAsync();
            return (updatedOrders > 0);
        }
    }
}
