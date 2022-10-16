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
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => "User")).ReverseMap();
<<<<<<< HEAD
            CreateMap<ThingDto, Thing>().ReverseMap();
=======
            CreateMap<ThingDTO, Thing>().ReverseMap();
            CreateMap<PhotoThingDTO, PhotoThing>().ReverseMap();
>>>>>>> Test
        }
    }
}
