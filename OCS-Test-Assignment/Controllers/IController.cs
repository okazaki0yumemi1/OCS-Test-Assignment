﻿using Microsoft.AspNetCore.Mvc;

namespace OCS_Test_Assignment.Controllers
{
    public interface IController<T> where T : Models.Entity
    {
        Task<IActionResult> Create(T obj);
        Task<IActionResult> Delete(string Id);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetByID(string Id);
        Task<IActionResult> Update(string Id, T obj);//Guid Id, T obj);
    }
}
