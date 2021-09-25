using EmployeesAPI.Models;
using System.Collections.Generic;
using EmployeesAPI.Dtos;

namespace EmployeesAPI.Services
{
    public interface IEmployeeServices
    {
        public void CreateEmployee(EmployeeReadDto employeeDto);

        public List<Employee> ReadEmployees();

        public EmployeeReadDto ReadEmployee(int id);

        public void UpdateEmployee(EmployeeUpdateDto EmployeeUpdate);

        public void DeleteEmployee(int id);
    }
}