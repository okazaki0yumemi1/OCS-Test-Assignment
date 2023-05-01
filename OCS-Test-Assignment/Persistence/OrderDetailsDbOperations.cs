using OCS_Test_Assignment.Models;

namespace OCS_Test_Assignment.Persistence
{
    public class OrderDetailsDbOperations : IDbOperations<OrderDetails>
    {
        Task<bool> IDbOperations<OrderDetails>.CreateAsync(OrderDetails obj)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDbOperations<OrderDetails>.DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<List<OrderDetails>> IDbOperations<OrderDetails>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<OrderDetails> IDbOperations<OrderDetails>.GetByIDAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDbOperations<OrderDetails>.UpdateAsync(OrderDetails obj)
        {
            throw new NotImplementedException();
        }
    }
}
