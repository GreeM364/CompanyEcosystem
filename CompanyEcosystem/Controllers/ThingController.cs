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
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        public ThingController(IThingService service, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _thingService = service;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<ThingDto> thingsDtos = _thingService.GetThings();

                var things = _mapper.Map<IEnumerable<ThingDto>, List<ThingViewModel>>(thingsDtos);

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
        public IActionResult Post(CreateThingViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
<<<<<<< HEAD
                var thingDto = _mapper.Map<ThingViewModel, ThingDto>(model);
=======
                var thingDto = _mapper.Map<CreateThingViewModel, ThingDTO>(model);
>>>>>>> Test

                var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "things");

               // _thingService.CreateThing(thingDto, file, directoryPath);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ThingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var thingDto = _mapper.Map<ThingViewModel, ThingDto>(model);

                _thingService.UpdateThing(thingDto);

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
