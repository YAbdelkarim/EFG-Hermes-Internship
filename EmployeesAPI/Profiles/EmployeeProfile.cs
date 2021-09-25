using AutoMapper;
using EmployeesAPI.Models;
using EmployeesAPI.Dtos;

namespace EmployeesAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeReadDto, Employee>();
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}