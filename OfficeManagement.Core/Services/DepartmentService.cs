using MongoDB.Driver;
using OfficeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeManagement.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoCollection<Department> _departments;
        public DepartmentService(IDbClient dbClient)
        {
            _departments = dbClient.GetDepartmentsCollection();
        }
        public Department Add(Department department)
        {
            //insertOne has major issue that it doesnt return the ID of newly created db object.
            // SEE -> https://jira.mongodb.org/browse/CSHARP-3289
            _departments.InsertOne(department);

            return department;
        }

        public Department Update(Department department)
        {
            _departments.ReplaceOne(x => x.Id == department.Id, department);
            return department;
        }

        public async Task<bool> Delete(string departmentId)
        {
            var result = await _departments.DeleteOneAsync(x => x.Id == departmentId);
            return result.IsAcknowledged;
        }

        public async Task<Department> Get(string departmentId)
        {
            return await _departments.Find(x => x.Id == departmentId).FirstOrDefaultAsync();
        }

        public async Task<List<Department>> GetAll()
        {
            return await _departments.Find(FilterDefinition<Department>.Empty).ToListAsync();
        }
    }
}
