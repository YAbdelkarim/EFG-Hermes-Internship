using DepartmentsAPI.Models;
using System.Collections.Generic;
using DepartmentsAPI.Dtos;

namespace DepartmentsAPI.Services
{
    public interface IDepartmentServices
    {
        public void CreateDepartment(DepartmentReadDto department);

        public List<Department> ReadDepartments();

        public DepartmentReadDto ReadDepartment(int id);

        public void UpdateDepartment(DepartmentUpdateDto DepartmentUpdate);

        public void DeleteDepartment(int id);
    }
}