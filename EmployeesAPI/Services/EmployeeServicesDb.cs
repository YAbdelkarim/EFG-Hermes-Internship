using System.Collections.Generic;
using EmployeesAPI.Models;
using EmployeesAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
using AutoMapper;
using EmployeesAPI.Dtos;

namespace EmployeesAPI.Services
{
    public class EmployeeServicesDb : IEmployeeServices
    {
        EmployeeContext _employeeContext = null;
        private readonly IMapper _mapper = null;

        public EmployeeServicesDb(EmployeeContext employeeContext, IMapper mapper)
        {
            this._employeeContext = employeeContext;
            this._mapper = mapper;
        }

        public void CreateEmployee(EmployeeReadDto employeeDto){
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        public List<Employee> ReadEmployees(){
            return _employeeContext.Employees.ToList();
        }

        public EmployeeReadDto ReadEmployee(int id){
            Employee employee = _employeeContext.Employees.Find(id);
            EmployeeReadDto employeeDto = _mapper.Map<EmployeeReadDto>(employee);
            return employeeDto;
        }

        public void UpdateEmployee(EmployeeUpdateDto employeeDto){
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _employeeContext.Entry(employee).State = EntityState.Modified;
            _employeeContext.SaveChanges();
        }

        public void DeleteEmployee(int id){
            Employee employeeToDelete = _employeeContext.Employees.Find(id);
            _employeeContext.Employees.Remove(employeeToDelete);
            _employeeContext.SaveChanges();
        }
    }
}