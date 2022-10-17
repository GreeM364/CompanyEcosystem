using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<LocationCreateUpdateViewModel, LocationDto>().ReverseMap();
            CreateMap<QuestionnaireCreateUpdateViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeDto>().ReverseMap();
            CreateMap<ThingViewModel, ThingDto>().ReverseMap();
            CreateMap<ThingCreateUpdateViewModel, ThingDto>().ReverseMap();
            CreateMap<PhotoThingViewModel, PhotoThingDto>().ReverseMap();
        }
    }
}
