namespace OfficeManagement.WebApi.Requests
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string DepartmentId { get; set; }
    }
}
