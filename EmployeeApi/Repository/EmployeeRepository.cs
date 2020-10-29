using EmployeeApi.Data;
using EmployeeApi.Interfaces;
using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<string> DeleteEmployeeAsync(Employee emp)
        {
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return "Deleted";
        }

        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await _dbContext.Department.ToListAsync();
        }

        public async Task<List<DepartmentWithEmployee>> GetDepartmentWithEmployeeAsync()
        {
            var depts = await _dbContext.Department.ToListAsync();
            List<DepartmentWithEmployee> departmentWithEmployee = new List<DepartmentWithEmployee>();
            foreach (var item in depts)
            {
                var emps = await _dbContext.Employees.Where(e => e.DepartmentId == item.Id)
                    .Select(e => new EmployeeInfo { Id = e.Id, Name = e.Name }).ToListAsync();
                departmentWithEmployee.Add(new DepartmentWithEmployee { Department = item, Employees = emps });
            }
            return departmentWithEmployee;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _dbContext.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByDeptAsync(int id)
        {
            var emps = await _dbContext.Employees.Where(e => e.DepartmentId == id).ToListAsync();
            return emps;
        }

        public async Task<List<Employee>> GetEmployeesWithDeptAsync()
        {
            return await _dbContext.Employees.Include("Department").ToListAsync();
        }

        public async Task<Employee> GetEmployeeWithDeptAsync(int id)
        {
            return await _dbContext.Employees.Include("Department").Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee emp, Employee employee)
        {
            emp.Address = employee.Address;
            emp.Name = employee.Name;
            emp.Age = employee.Age;
            emp.CompanyName = employee.CompanyName;
            emp.DepartmentId = employee.DepartmentId;
            await _dbContext.SaveChangesAsync();
            return emp;
        }
    }
}
