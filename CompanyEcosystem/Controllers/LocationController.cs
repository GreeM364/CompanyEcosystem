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
        public IActionResult Get()
        {
            try
            {
                IEnumerable<LocationDTO> locationDtos = _locationService.GetLocations();

                var locations = _mapper.Map<IEnumerable<LocationDTO>, List<LocationViewModel>>(locationDtos);

                return Ok(locations);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

                _locationService.CreateLocation(locationDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(LocationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var locationDto = _mapper.Map<LocationViewModel, LocationDTO>(model);

                _locationService.UpdateLocation(locationDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            try
            {
                _locationService.DeleteLocation(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
