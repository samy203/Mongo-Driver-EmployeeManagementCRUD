using MongoDB.Driver;
using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        private readonly IMongoCollection<Department> _departments;
        public EmployeeService(IDbClient dbClient)
        {
            _employees = dbClient.GetEmployeesCollection();
            _departments = dbClient.GetDepartmentsCollection();
        }
        public Employee Add(Employee employee)
        {
            //insertOne has major issue that it doesnt return the ID of newly created db object.
            // SEE -> https://jira.mongodb.org/browse/CSHARP-3289
            _employees.InsertOne(employee);

            return employee;
        }

        public Employee Update(Employee employee)
        {
            _employees.ReplaceOne(x => x.Id == employee.Id, employee);
            return employee;
        }

        public async Task<bool> Delete(string employeeId)
        {
            var result = await _employees.DeleteOneAsync(x => x.Id == employeeId);
            return result.IsAcknowledged;
        }

        //will make default retrieval includes the department document
        public Employee Get(string employeeId)
        {
           var employee = _employees.AsQueryable().Where(x => x.Id == employeeId);

            var query = from p in employee
                   join d in _departments.AsQueryable() on p.DepartmentId equals d.Id into Department
                   select new Employee
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Age = p.Age,
                       Salary = p.Salary,
                       DepartmentId = Department.First().Id,
                       Department = Department.First(),
                   };

            return query.FirstOrDefault();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employees.Find(FilterDefinition<Employee>.Empty).ToListAsync();
        }
    }
}
