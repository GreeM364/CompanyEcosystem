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
        }
    }
}
