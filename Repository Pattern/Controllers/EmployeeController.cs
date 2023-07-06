using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Interface;
using Repository_Pattern.Repository;
using Repository_Pattern.Models;

namespace Repository_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo repo)
        {
                 _employeeRepo = repo;
        }

        
        [HttpGet]
        [Route("EmployeeList")]
        public IActionResult Get(int? id)
        {
            if (id.HasValue)
            {
                var employee = _employeeRepo.GetEmployeeById(id.Value);
                return Ok(employee);
            }
            else
            {
                var employees = _employeeRepo.GetEmployees();
                return Ok(employees);
            }

        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Create(Employee employee)
        {
            _employeeRepo.CreateEmployee(employee);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();


            _employeeRepo.UpdateEmployee(employee);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            _employeeRepo.DeleteEmployee(id);
            return Ok();
        }
    }
}
