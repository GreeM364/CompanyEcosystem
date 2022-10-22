using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL.Infrastructure
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<LocationCreateUpdateViewModel, LocationDto>().ReverseMap();
            CreateMap<LocationViewModel, LocationDto>().ForMember(dest => dest.Employees,
                    opt => opt.MapFrom(src => src.Employees)).ReverseMap();
            CreateMap<QuestionnaireCreateUpdateViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeDto>().ReverseMap();
            CreateMap<ThingViewModel, ThingDto>().ReverseMap();
            CreateMap<ThingCreateUpdateViewModel, ThingDto>().ReverseMap();
            CreateMap<PhotoThingViewModel, PhotoThingDto>().ReverseMap();
        }
    }
}
