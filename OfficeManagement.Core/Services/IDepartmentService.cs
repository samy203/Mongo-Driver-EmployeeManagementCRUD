using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagement.Core.Services
{
    public interface IDepartmentService
    {
        Department Add(Department department);
        Department Update(Department department);
        Task<Department> Get(string departmentId);
        Task<List<Department>> GetAll();
        Task<bool> Delete(string departmentId);
    }
}
