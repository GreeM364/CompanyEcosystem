using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public LocationController(ILocationService locationService, IMapper mapper, IAccountService accountService)
        {
            _locationService = locationService;
            _mapper = mapper;
            _accountService = accountService;
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
                var source = _mapper.Map<LocationDTO, LocationViewModel>(_locationService.GetLocation(id));

                var locationViewModel = new LocationViewModel
                {
                    Id = source.Id,
                    Title = source.Title,
                    Chief = source.Chief,
                    WorkingStart = source.WorkingStart,
                    WorkingEnd = source.WorkingEnd,
                    AuthenticateResponse = _mapper.Map<IEnumerable<EmployeeDTO>, List<AuthenticateResponse>>(_accountService.GetAll())
                }; // TODO: ????????????????????

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
