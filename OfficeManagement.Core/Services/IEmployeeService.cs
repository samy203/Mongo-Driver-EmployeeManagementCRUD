using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagement.Core.Services
{
    public interface IEmployeeService
    {
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Get(string employeeId);
        Task<List<Employee>> GetAll();
        Task<bool> Delete(string employeeId);
    }
}
