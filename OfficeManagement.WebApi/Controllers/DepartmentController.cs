﻿using Microsoft.AspNetCore.Mvc;
using OfficeManagement.Core.Models;
using OfficeManagement.Core.Services;
using OfficeManagement.WebApi.Requests;
using System.Threading.Tasks;

namespace OfficeManagement.WebApi.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpPost()]
        public JsonResult AddDepartment([FromBody] CreateDepartmentRequest request)
        {
            // can use auto mapper
            var department = new Department
            {
                Id = null,
                Name = request.Name,
            };

            var result = _departmentService.Add(department);

            return Json(result);
        }

        [HttpPut("{id}")]
        public JsonResult UpdateDepartment(string id, [FromBody] UpdateDepartmentRequest request)
        {
            // can use auto mapper
            var department = new Department
            {
                Id = id,
                Name = request.Name,
            };

            var result = _departmentService.Update(department);

            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetDepartment(string id)
        {
            return Json(await _departmentService.Get(id));
        }

        [HttpGet()]
        public async Task<JsonResult> GetDepartments()
        {
            return Json(await _departmentService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteDepartment(string id)
        {
            return Json(await _departmentService.Delete(id));
        }
    }
}
