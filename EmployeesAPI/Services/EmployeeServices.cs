using System.Collections.Generic;
using System.Linq; 
using EmployeesAPI.Models;
using AutoMapper;
using EmployeesAPI.Dtos;

namespace EmployeesAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        List<Employee> _employeeList = null;
        private readonly IMapper _mapper = null;

        public EmployeeServices(IMapper mapper)
        {
            _employeeList = new List<Employee>();
            this._mapper = mapper;
        }

        public void CreateEmployee(EmployeeReadDto employeeDto){
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _employeeList.Add(employee);
        }

        public List<Employee> ReadEmployees(){
            return _employeeList;
        }

        public EmployeeReadDto ReadEmployee(int id){
            foreach (Employee employee in _employeeList)
            {
                if(employee.EmployeeId == id){
                    EmployeeReadDto employeeDto = _mapper.Map<EmployeeReadDto>(employee);
                    return employeeDto;
                }
            }
            return null;
        }

        public void UpdateEmployee(EmployeeUpdateDto EmployeeUpdate){
            for (int count = 0; count < _employeeList.Count; count++)
            {
                if(_employeeList[count].EmployeeId == EmployeeUpdate.EmployeeId)
                {
                    _employeeList[count] = _mapper.Map<Employee>(EmployeeUpdate);
                    break;
                }
            }
        }

        public void DeleteEmployee(int id){
            foreach (Employee employee in _employeeList)
            {
                if(employee.EmployeeId == id)
                {
                    _employeeList.Remove(employee);
                    break;
                }
            }
        }
    }
}