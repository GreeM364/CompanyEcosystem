using System.Linq.Expressions;
using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace CompanyEcosystem.BL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _dbLocation;
        private readonly IRepository<Employee> _dbEmployee;
        private readonly IMapper _mapper;

        public LocationService(IRepository<Location> dbLocation, IRepository<Employee> dbEmployee, IMapper mapper)
        {
            _dbLocation = dbLocation;
            _dbEmployee = dbEmployee;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> GetLocationsAsync()
        {
            var source = await _dbLocation.GetAsync(includes: new List<Expression<Func<Location, object>>>()
            {
                x => x.Employees,
            });
            
            if (source == null || !source.Any())
                throw new ValidationException("Locations not found", "");

            var locations = _mapper.Map<List<Location>, List<LocationDto>>(source);

            foreach (var location in locations)
            {
                location.ChiefEmail = (await _dbEmployee.GetByIdAsync(location.Chief)).Email;
            }

            return locations;
        }

        public async Task<LocationDto> GetLocationAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            var source = await _dbLocation.GetByIdAsync(id.Value);
            var employes = await _dbEmployee.GetAsync(employee => employee.LocationId == source.Id);

            if (source == null)
                throw new ValidationException("Locations not found", "");

            var locationDto = _mapper.Map<Location, LocationDto>(source);
            var employesDto = _mapper.Map<List<Employee>, List<EmployeeDto>>(employes);

            locationDto.ChiefEmail = (await _dbEmployee.GetByIdAsync(locationDto.Chief))!.Email;
            locationDto.Employees = employesDto;

            return locationDto;
        }

        public async Task CreateLocationAsync(LocationDto locationDto, IFormFile formFile, string directoryPath)
        {
            var chief = await _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            if (formFile != null && !string.IsNullOrWhiteSpace(directoryPath))
            {
                directoryPath = Path.Combine(directoryPath, location.Id.ToString());

                if (!Directory.Exists(directoryPath))
                {
                    var dirInfo = new DirectoryInfo(directoryPath);
                    dirInfo.Create();
                }
            }

            var path = $"/img/locations/{locationDto.Id}/{formFile.FileName}";

            using (var fileStream = new FileStream(Path.Combine(directoryPath, formFile.FileName), FileMode.Create))
            {
                formFile.CopyToAsync(fileStream);
            }

            location.Photo = path;
            await _dbLocation.CreateAsync(location);
        }

        public async Task UpdateLocationAsync(LocationDto locationDto, IFormFile formFile, string directoryPath)
        {
            var chief = await _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            if (formFile != null)
            {
                if (!string.IsNullOrWhiteSpace(directoryPath))
                {
                    directoryPath = Path.Combine(directoryPath, location.Id.ToString());

                    if (!Directory.Exists(directoryPath))
                    {
                        var dirInfo = new DirectoryInfo(directoryPath);
                        dirInfo.Create();
                    }
                }

                var path = $"/img/locations/{locationDto.Id}/{formFile.FileName}";

                using (var fileStream = new FileStream(Path.Combine(directoryPath, formFile.FileName), FileMode.Create))
                {
                    formFile.CopyToAsync(fileStream);
                }

                location.Photo = path;
            }

            await _dbLocation.UpdateAsync(location);
        }

        public Task DeleteLocationAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            return _dbLocation.DeleteAsync(id.Value);
        }
    }
}
