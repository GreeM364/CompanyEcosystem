using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThingController : ControllerBase
    {
        private readonly IThingService _thingService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMapper _mapper;
        
        public ThingController(IThingService service, IWebHostEnvironment appEnvironment, IMapper mapper)
        {
            _thingService = service;
            _appEnvironment = appEnvironment;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var source = _thingService.GetThings();

                var things = _mapper.Map<IEnumerable<ThingDto>, List<ThingViewModel>>(source);

                return Ok(things);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            try
            {
                var source = _thingService.GetThing(id);

                var thing = _mapper.Map<ThingDto, ThingViewModel>(source);

                return Ok(thing);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ThingCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var thingDto = _mapper.Map<ThingCreateUpdateViewModel, ThingDto>(model);

                var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "things");

                _thingService.CreateThing(thingDto, model.Images, directoryPath);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ThingCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var thingDto = _mapper.Map<ThingCreateUpdateViewModel, ThingDto>(model);

                var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "things");

                _thingService.UpdateThing(thingDto, model.Images, directoryPath);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            try
            {
                _thingService.DeleteThing(id);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
