using AutoMapper;
using Employee_Management_System.API.Models;
using Employee_Management_System.API.Models.Dto;

namespace Employee_Management_System.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
