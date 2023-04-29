namespace OCS_Test_Assignment.Persistence
{
    public interface IDbOperations<T> where T : Models.Entity
    {
        Task<bool> CreateAsync(T obj);
        Task<bool> DeleteAsync(Guid Id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(Guid Id);
        Task<bool> UpdateAsync(T obj);
    }
}
