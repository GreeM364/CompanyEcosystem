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
        }
    }
}
