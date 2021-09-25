using System.Collections.Generic;
using System.Linq; 
using DepartmentsAPI.Models;
using AutoMapper;
using DepartmentsAPI.Dtos;

namespace DepartmentsAPI.Services
{
    public class DepartmentServices : IDepartmentServices
    {   
        List<Department> _departmentsList = null;
        private readonly IMapper _mapper = null;

        public DepartmentServices(IMapper mapper)
        {
            this._departmentsList = new List<Department>(); 
            this._mapper = mapper;
        }

        public void CreateDepartment(DepartmentReadDto departmentDto){
            Department department = _mapper.Map<Department>(departmentDto);
            _departmentsList.Add(department);
        }

        public List<Department> ReadDepartments(){
            return _departmentsList;
        }

        public DepartmentReadDto ReadDepartment(int id){
            foreach (Department department in _departmentsList)
            {
                if(department.DepartmentId == id){
                    DepartmentReadDto departmentDto = _mapper.Map<DepartmentReadDto>(department); 
                    return departmentDto;
                }
            }
            return null;
        }

        public void UpdateDepartment(DepartmentUpdateDto DepartmentUpdate){
            for (int count = 0; count < _departmentsList.Count; count++)
            {
                if(_departmentsList[count].DepartmentId == DepartmentUpdate.DepartmentId)
                {
                    _departmentsList[count] = _mapper.Map<Department>(DepartmentUpdate);
                    break;
                }
            }
        }

        public void DeleteDepartment(int id){
            foreach (Department department in _departmentsList)
            {
                if(department.DepartmentId == id)
                {
                    _departmentsList.Remove(department);
                    break;
                }
            }
        }
    }
}