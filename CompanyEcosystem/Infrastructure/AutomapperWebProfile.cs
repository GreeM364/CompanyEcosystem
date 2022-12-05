using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.PL.Models;

namespace CompanyEcosystem.PL.Infrastructure
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<LocationCreateViewModel, LocationDto>().ReverseMap();
            CreateMap<LocationUpdateViewModel, LocationDto>().ReverseMap();
            CreateMap<LocationViewModel, LocationDto>().ForMember(dest => dest.Employees,
                    opt => opt.MapFrom(src => src.Employees)).ReverseMap();
            CreateMap<QuestionnaireCreateViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<QuestionnaireUpdateViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<QuestionnaireViewModel, QuestionnaireDto>().ReverseMap();
            CreateMap<RegisterViewModel, EmployeeDto>().ReverseMap();
            CreateMap<AuthenticateViewModel, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeDto>().ReverseMap();
            CreateMap<ThingViewModel, ThingDto>().ReverseMap();
            CreateMap<ThingCreateViewModel, ThingDto>().ReverseMap();
            CreateMap<ThingUpdateViewModel, ThingDto>().ReverseMap();
            CreateMap<PhotoThingViewModel, PhotoThingDto>().ReverseMap();
            CreateMap<PostCreateUpdateViewModel, PostDto>().ReverseMap();
            CreateMap<PostViewModel, PostDto>().ReverseMap();
        }
    }
}
