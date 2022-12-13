using Microsoft.AspNetCore.Mvc;
using OfficeManagement.Core.Models;
using OfficeManagement.Core.Services;
using OfficeManagement.WebApi.Requests;
using System.Threading.Tasks;

namespace OfficeManagement.WebApi.Controllers
{
    [Route("[controller]")]
    public class EmoloyeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmoloyeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost()]
        public JsonResult AddEmployee([FromBody] CreateEmployeeRequest request)
        {
            // can use auto mapper
            var employee = new Employee
            {
                Id = null,
                Name = request.Name,
                Age = request.Age,
                Salary = request.Salary,
                DepartmentId = request.DepartmentId
            };

            var result = _employeeService.Add(employee);

            return Json(result);
        }

        [HttpPut("{id}")]
        public JsonResult UpdateEmployee(string id, [FromBody] UpdateEmployeeRequest request)
        {
            // can use auto mapper
            var employee = new Employee
            {
                Id = id,
                Name = request.Name,
                Age = request.Age,
                Salary = request.Salary,
                DepartmentId = request.DepartmentId
            };

            var result = _employeeService.Update(employee);

            return Json(result);
        }
        [HttpGet("{id}")]
        public JsonResult GetEmployee(string id)
        {
            return Json(_employeeService.Get(id));
        }

        [HttpGet()]
        public async Task<JsonResult> GetEmployees()
        {
            return Json(await _employeeService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteEmoployee(string id)
        {
            return Json(await _employeeService.Delete(id));
        }
    }
}
