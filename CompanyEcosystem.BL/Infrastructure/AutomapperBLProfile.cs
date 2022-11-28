using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Infrastructure
{
    public class AutomapperBLProfile : Profile
    {
        public AutomapperBLProfile()
        {
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<QuestionnaireDto, Questionnaire>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().
                ForMember(dest => dest.Password,
                    opt => opt.MapFrom(src => HashPassword.HashPas(src.Password)))
                .ReverseMap();
            CreateMap<ThingDto, Thing>().ReverseMap();
            CreateMap<PhotoThingDto, PhotoThing>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
