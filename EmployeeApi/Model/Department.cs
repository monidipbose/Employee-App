using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
