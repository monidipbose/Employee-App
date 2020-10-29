using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public Department Department { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
