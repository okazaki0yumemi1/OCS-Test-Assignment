using Microsoft.AspNetCore.Mvc;

namespace OCS_Test_Assignment.Controllers
{
    public interface IController<T> where T : Models.Entity
    {
        Task<IActionResult> Create(T obj);
        Task<IActionResult> Delete(Guid Id);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetByID(Guid Id);
        Task<IActionResult> Update(Guid Id, T obj);
    }
}
