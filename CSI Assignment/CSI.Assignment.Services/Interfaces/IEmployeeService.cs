using CSI.Assignment.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Assignment.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();
        bool AddEmployee(EmployeeDTO employeeDTO);
        bool UpdateEmployee(int id, EmployeeDTO employeeDTO);
        bool DeleteEmployee(int id);
    }
}
