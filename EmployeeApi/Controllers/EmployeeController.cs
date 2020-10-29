using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Interfaces;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<EmployeeController>/departmentswithemployee
        [HttpGet("departmentswithemployee")]
        public async Task<ActionResult> GetDepartmentWithEmployee()
        {
            return Ok(await _repo.GetDepartmentWithEmployeeAsync());
        }
        // GET: api/<EmployeeController>/departments
        [HttpGet("departments")]
        public async Task<ActionResult> GetDepartment()
        {
            return Ok(await _repo.GetDepartmentAsync());
        }

        // GET: api/<EmployeeController>/bydept/1
        [HttpGet("bydept/{id}")]
        public async Task<ActionResult> GetEmployeesByDept(int id, int? pageNumber, int? pageSize)
        {
            var emps = await _repo.GetEmployeesByDeptAsync(id);
            var defaultPageNumber = pageNumber ?? 1;
            var defaultPageSize = pageSize ?? 5;
            return Ok(emps.Skip((defaultPageNumber - 1) * defaultPageSize).Take(defaultPageSize));
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _repo.GetEmployeesAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var emp = await _repo.GetEmployeeAsync(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return NotFound("Not Found");
        }

        // GET: api/<EmployeeController>/all
        [HttpGet("all")]
        public async Task<ActionResult> GetEmployeesWithDept()
        {
            return Ok(await _repo.GetEmployeesWithDeptAsync());
        }

        // GET api/<EmployeeController>/all/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult> GetEmployeeWithDept(int id)
        {
            var emp = await _repo.GetEmployeeWithDeptAsync(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return NotFound("Not Found");
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
        {
            return Ok(await _repo.AddEmployeeAsync(employee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var emp = await _repo.GetEmployeeAsync(id);
            if (emp != null)
            {
                return Ok(await _repo.UpdateEmployeeAsync(emp, employee));
            }
            return NotFound("Not Found");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var emp = await _repo.GetEmployeeAsync(id);
            if (emp != null)
            {
                return Ok(await _repo.DeleteEmployeeAsync(emp));
            }
            return NotFound("Not Found");
        }
    }
}
