using AutoMapper;
using Jobs.Dtos;
using Jobs.Models;
using Jobs.Profiles;

namespace Jobs.Mapping
{
    public static class EmployeeMapper
    {
        private static readonly IMapper _mapper;
        static EmployeeMapper()
        {
            _mapper = new MapperConfiguration(configProfile => configProfile.AddProfile<EmployeeProfiles>()).CreateMapper();
        }
        public static Employee ModelToDto(this EmployeeDtos employeeDtos)
        {
           return _mapper.Map<EmployeeDtos, Employee>(employeeDtos);
        }
        public static EmployeeDtos DtosToModel(this Employee employee)
        {
            return _mapper.Map<Employee, EmployeeDtos>(employee);
        }
    }
}
