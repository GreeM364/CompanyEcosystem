using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private ILocationService LocationService;
        public LocationController(ILocationService locationService)
        {
            LocationService = locationService;
        }

        [HttpGet]
        public IEnumerable<LocationViewModel> Get()
        {
            IEnumerable<LocationDTO> locationDTOs = LocationService.GetLocations();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LocationDTO, LocationViewModel>()).CreateMapper();
            var locations = mapper.Map<IEnumerable<LocationDTO>, List<LocationViewModel>>(locationDTOs);
            
            return locations;
        }

        [HttpGet("{id}")]
        public LocationViewModel Get(int? id)
        {
            try
            {
                LocationDTO locationDTO = LocationService.GetLocation(id);
                var locationViewModel = new LocationViewModel { Id = locationDTO.Id, Title = locationDTO.Title, 
                    Chief = locationDTO.Chief, WorkingStart = locationDTO.WorkingStart, WorkingEnd = locationDTO.WorkingEnd }; ;

                return locationViewModel;
            }
            catch (ValidationException ex)
            {
                return new LocationViewModel();
                // TODO: зробити відображення помилки 
            }
        }
    }
}
