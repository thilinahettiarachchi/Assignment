using CSI.Assignment.DTO.Employee;
using CSI.Assignment.Entity.Context;
using CSI.Assignment.Entity.Entities;
using CSI.Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Assignment.Repositories.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
                var result = _context.Employees.ToList();

                foreach (var employee in result)
                {
                    employeeList.Add(new EmployeeDTO()
                    {
                        Id = employee.Id,
                        EmployeeCode = employee.EmployeeCode,
                        EmployeeName = employee.EmployeeName,
                        EmployeeDesignation = employee.EmployeeDesignation,
                    });
                }

                return employeeList;
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
                if (employeeDTO != null)
                {
                    var employee = new Employee()
                    {
                        EmployeeCode = employeeDTO.EmployeeCode,
                        EmployeeName = employeeDTO.EmployeeName,
                        EmployeeDesignation = employeeDTO.EmployeeDesignation
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                }
                
                return true;
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
                var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (employee != null)
                {
                    employee.EmployeeCode = employeeDTO.EmployeeCode;
                    employee.EmployeeName = employeeDTO.EmployeeName;
                    employee.EmployeeDesignation = employeeDTO.EmployeeDesignation;

                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                }
                return true;
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
                if (id != 0)
                {
                    _context.Employees.Where(x => x.Id == id).ExecuteDelete();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
