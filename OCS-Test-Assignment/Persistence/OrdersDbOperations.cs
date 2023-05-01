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
            await _dbContext.OrderDetails.AddRangeAsync(obj.Lines);
            var createdOrders = await _dbContext.SaveChangesAsync();
            return (createdOrders > 0);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var exist = await GetByIDAsync(Id);
            if (exist == null) return false;
            _dbContext.Orders.Remove(exist);
            _dbContext.OrderDetails.RemoveRange(exist.Lines);
            var deletedClients = await _dbContext.SaveChangesAsync();
            if (deletedClients > 1) return true;
            else return false;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.Include(od => od.Lines).ToListAsync();
        }

        public async Task<Order> GetByIDAsync(Guid Id)
        {
            var order = await _dbContext.Orders.Include(od => od.Lines).SingleOrDefaultAsync(x => x.Id == Id);
            //var lines = await _dbContext.OrderDetails.AllAsync()
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
