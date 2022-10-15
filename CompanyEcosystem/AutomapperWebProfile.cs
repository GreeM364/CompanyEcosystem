using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<LocationViewModel, LocationDTO>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDTO>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<AuthenticateResponseViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<ThingViewModel, ThingDTO>().ReverseMap();
        }
    }
}
