using AutoMapper;
using DepartmentsAPI.Models;
using DepartmentsAPI.Dtos;

namespace DepartmentsAPI.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentReadDto, Department>();
            CreateMap<Department, DepartmentReadDto>();
            CreateMap<DepartmentUpdateDto, Department>();
        }
    }
}