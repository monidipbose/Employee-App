using System.Collections.Generic;

namespace EmployeeApi.Model
{
    public class DepartmentWithEmployee
    {
        public Department Department { get; set; }
        public List<EmployeeInfo> Employees { get; set; }
    }
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
