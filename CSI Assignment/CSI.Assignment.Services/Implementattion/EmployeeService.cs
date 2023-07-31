using CSI.Assignment.DTO.Employee;
using CSI.Assignment.Repositories.Implementation;
using CSI.Assignment.Repositories.Interfaces;
using CSI.Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Assignment.Services.Implementattion
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                return _employeeRepository.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                return _employeeRepository.AddEmployee(employeeDTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                return _employeeRepository.UpdateEmployee(id,employeeDTO);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                return _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
