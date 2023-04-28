﻿using Microsoft.AspNetCore.Mvc;

namespace OCS_Test_Assignment.Controllers
{
    public interface IController<T> where T : Models.Entity
    {
        Task<IActionResult> Create(T obj);
        Task<IActionResult> Delete(int Id);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetByID(int Id);
        Task<IActionResult> Update(int Id, T obj);
    }
}
