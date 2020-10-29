using EmployeeApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<DepartmentWithEmployee>> GetDepartmentWithEmployeeAsync();
        Task<List<Department>> GetDepartmentAsync();
        Task<List<Employee>> GetEmployeesByDeptAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<List<Employee>> GetEmployeesWithDeptAsync();
        Task<Employee> GetEmployeeWithDeptAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee emp, Employee employee);
        Task<string> DeleteEmployeeAsync(Employee emp);
    }
}
