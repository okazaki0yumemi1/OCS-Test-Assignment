using Microsoft.Extensions.Caching.Memory;
using OCS_Test_Assignment.Models;

namespace OCS_Test_Assignment.Persistence
{
    public class OrdersDbOperations : IDbOperations<Order>
    {
        private readonly DatabaseContext _dbContext;
        public OrdersDbOperations(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> CreateAsync(Order obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIDAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
