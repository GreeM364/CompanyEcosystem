﻿using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
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
        private readonly IWebHostEnvironment _appEnvironment;

        public LocationController(ILocationService locationService, IMapper mapper, IAccountService accountService, IWebHostEnvironment appEnvironment)
        {
            _locationService = locationService;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var source = await _locationService.GetLocationsAsync();

                var locations = _mapper.Map<List<LocationDto>, List<LocationViewModel>>(source);

                return Ok(locations);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var source = await _locationService.GetLocationAsync(id);

                var location = _mapper.Map<LocationDto, LocationViewModel>(source);

                return Ok(location);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LocationCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            if (model.Photo == null)
            {
                BadRequest(model);
                return BadRequest("Added photo");
            }

            try
            {
                var locationDto = _mapper.Map<LocationCreateUpdateViewModel, LocationDto>(model);

                var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "locations");

                await _locationService.CreateLocationAsync(locationDto, model.Photo, directoryPath);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(LocationCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var locationDto = _mapper.Map<LocationCreateUpdateViewModel, LocationDto>(model);

                var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "locations");

                await _locationService.UpdateLocationAsync(locationDto, model.Photo, directoryPath);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _locationService.DeleteLocationAsync(id);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
