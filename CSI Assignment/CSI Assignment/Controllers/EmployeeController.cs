using CSI.Assignment.DTO.Employee;
using CSI.Assignment.Services.Implementattion;
using CSI.Assignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSI_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = _employeeService.GetAllEmployees();
            return employees;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                if(_employeeService.AddEmployee(employeeDTO) == true)
                {
                    return Ok(new { message = "Employee added successfully.!" });
                }
                else
                {
                    return BadRequest(new { message = "Unable to add an Employee." });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                if(_employeeService.UpdateEmployee(id, employeeDTO) == true)
                {
                    return Ok(new { message = "Employee updated successfully.!" });
                }
                else
                {
                    return BadRequest(new { message = "Unable to update an Employee" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                if(_employeeService.DeleteEmployee(id) == true)
                {
                    return Ok(new { message = "Record deleted successfully.!" });
                }
                else
                {
                    return BadRequest(new { message = "Unable to delete the record" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
