using System.Collections.Generic;
using System.Linq; 
using DepartmentsAPI.Models;
using AutoMapper;
using DepartmentsAPI.Dtos;
using DepartmentsAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsAPI.Services
{
    public class DepartmentServicesDb : IDepartmentServices
    {   
        DepartmentContext _departmentContext = null;
        private readonly IMapper _mapper = null;

        public DepartmentServicesDb(DepartmentContext departmentContext ,IMapper mapper)
        {
            this._departmentContext = departmentContext;
            this._mapper = mapper;
        }

        public void CreateDepartment(DepartmentReadDto departmentDto){
            Department department = _mapper.Map<Department>(departmentDto);
            _departmentContext.Departments.Add(department);
            _departmentContext.SaveChanges();
        }

        public List<Department> ReadDepartments(){
            return _departmentContext.Departments.ToList();
        }

        public DepartmentReadDto ReadDepartment(int id){
            Department department = _departmentContext.Departments.Find(id);
            DepartmentReadDto departmentDto = _mapper.Map<DepartmentReadDto>(department);
            return departmentDto;
        }

        public void UpdateDepartment(DepartmentUpdateDto DepartmentUpdate){
            Department department = _mapper.Map<Department>(DepartmentUpdate);
            _departmentContext.Entry(department).State = EntityState.Modified;
            _departmentContext.SaveChanges();
        }

        public void DeleteDepartment(int id){
            Department department = _departmentContext.Departments.Find(id);
            _departmentContext.Departments.Remove(department);
            _departmentContext.SaveChanges();
        }
    }
}