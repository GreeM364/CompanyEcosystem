using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Infrastructure
{
    public class AutomapperBLProfile : Profile
    {
        public AutomapperBLProfile()
        {
            CreateMap<Location, LocationDto>().ForMember(dest => dest.Photo,
                opt => opt.MapFrom(src => СonverterImage.ImageToByteArray(src.Photo)))
                .ForMember(dest => dest.Path,
                    opt => opt.MapFrom(src => src.Photo))
                .ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDto>().ForMember(dest => dest.PhotoBytes,
                    opt => opt.MapFrom(src => СonverterImage.ImageToByteArray(src.Photo)))
                .ReverseMap();
            CreateMap<EmployeeDto, Employee>().
                ForMember(dest => dest.Password,
                    opt => opt.MapFrom(src => HashPassword.HashPas(src.Password)))
                .ReverseMap();
            CreateMap<ThingDto, Thing>().ReverseMap();
            CreateMap<PhotoThing, PhotoThingDto>().ForMember(dest => dest.Photo,
                    opt => opt.MapFrom(src => СonverterImage.ImageToByteArray(src.Path)))
                .ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
