using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Infrastructure
{
    public class AutomapperBLProfile : Profile
    {
        public AutomapperBLProfile()
        {
            CreateMap<LocationDTO, Location>().ReverseMap();
            CreateMap<QuestionnaireDTO, Questionnaire>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().
                ForMember(dest => dest.Password,
                    opt => opt.MapFrom(src => HashPassword.HashPas(src.Password)))
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => "User")).ReverseMap();
            CreateMap<ThingDTO, Thing>().ReverseMap();
            CreateMap<PhotoThingDTO, PhotoThing>().ReverseMap();
        }
    }
}
