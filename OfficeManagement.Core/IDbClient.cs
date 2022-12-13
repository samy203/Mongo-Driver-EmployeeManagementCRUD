using MongoDB.Driver;
using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagement.Core
{
    public interface IDbClient
    {
        IMongoCollection<Employee> GetEmployeesCollection();
        IMongoCollection<Department> GetDepartmentsCollection();
    }
}
