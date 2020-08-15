using AutoMapper;
using Carbon.Core.Models;
using Carbon.Models.DTO;

namespace Carbon
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //mapping profile for Employee
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();

            //mapping profile for Benefit
            CreateMap<Benefit, GetBenefitDto>();
            CreateMap<AddBenefitDto, Benefit>();
        }
    }
}
