using AutoMapper;
using Carbon.Core.Models;
using Carbon.Models.DTO;

namespace Carbon
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
        }
    }
}
