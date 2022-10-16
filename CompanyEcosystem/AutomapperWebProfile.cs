using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
<<<<<<< HEAD
            CreateMap<LocationViewModel, LocationDto>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateResponseViewModel, EmployeeDto>().ReverseMap();
            CreateMap<ThingViewModel, ThingDto>().ReverseMap();
=======
            CreateMap<LocationViewModel, LocationDTO>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDTO>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<AuthenticateResponseViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<ThingViewModel, ThingDTO>().ReverseMap();
            CreateMap<CreateThingViewModel, ThingDTO>().ReverseMap();
            CreateMap<PhotoThingViewModel, PhotoThingDTO>().ReverseMap();
>>>>>>> Test
        }
    }
}
