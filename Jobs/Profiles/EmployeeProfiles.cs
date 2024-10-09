using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;

namespace Jobs.Profiles
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, EmployeeDtos>().ReverseMap();
            CreateMap<EmployeeDtos, Employee>().ReverseMap();
        }
    }
}
