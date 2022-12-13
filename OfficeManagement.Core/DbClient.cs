using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagement.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Employee> _employees;
        private readonly IMongoCollection<Department> _departments;
        public DbClient(IOptions<OfficeManagementDBConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var database = client.GetDatabase(options.Value.Database_Name);
            _employees = database.GetCollection<Employee>(options.Value.Employees_Collection_Name);
            _departments = database.GetCollection<Department>(options.Value.Departments_Collection_Name);
        }
        public IMongoCollection<Employee> GetEmployeesCollection() => _employees;
        public IMongoCollection<Department> GetDepartmentsCollection() => _departments;
    }
}
