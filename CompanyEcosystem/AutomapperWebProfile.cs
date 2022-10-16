using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<LocationViewModel, LocationDto>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateResponseViewModel, EmployeeDto>().ReverseMap();
            CreateMap<ThingViewModel, ThingDto>().ReverseMap();
        }
    }
}
