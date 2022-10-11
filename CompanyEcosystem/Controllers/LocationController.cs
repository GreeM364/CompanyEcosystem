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
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LocationViewModel> Get()
        {
            IEnumerable<LocationDTO> locationDTOs = _locationService.GetLocations();

            var locations = _mapper.Map<IEnumerable<LocationDTO>, List<LocationViewModel>>(locationDTOs);
            
            return locations;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            try
            {
                LocationDTO locationDto = _locationService.GetLocation(id);

                var locationViewModel = _mapper.Map<LocationDTO, LocationViewModel>(locationDto);

                return Ok(locationViewModel);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(LocationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var locationDto = _mapper.Map<LocationViewModel, LocationDTO>(model);

                _locationService.PostLocation(locationDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
