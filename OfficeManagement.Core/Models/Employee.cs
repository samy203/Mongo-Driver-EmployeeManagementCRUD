using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfficeManagement.Core.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
