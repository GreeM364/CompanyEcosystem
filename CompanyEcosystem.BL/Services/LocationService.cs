using System.Linq.Expressions;
using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;

namespace CompanyEcosystem.BL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _dbLocation;
        private readonly IRepository<Employee> _dbEmployee;
        private readonly IMapper _mapper;

        public LocationService(IRepository<Location> dbLocation, IRepository<Employee> dbEmployee, IAccountService accountService, IMapper mapper)
        {
            _dbLocation = dbLocation;
            _dbEmployee = dbEmployee;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
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

        public LocationDto GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            var location = _dbLocation.GetByIdAsync(id.Value);

            if (location == null)
                throw new ValidationException("Location not found", "");

            var locationDto = new LocationDto() 
            {
                Id = location.Id,
                Title = location.Title,
                ChiefEmail = _dbEmployee.GetByIdAsync(location.Result.Chief).Email,
                WorkingStart = location.WorkingStart,
                WorkingEnd = location.WorkingEnd,
                Employees = _dbEmployee.GetAsync(l => l.Id == location.Result.Id)
            };

            return locationDto;
        }

        public async Task CreateLocationAsync(LocationDto locationDto)
        {
            var chief = await _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            await _dbLocation.CreateAsync(location);
        }

        public Task UpdateLocationAsync(LocationDto locationDto)
        {
            var chief = _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            return _dbLocation.UpdateAsync(location);
        }

        public Task DeleteLocationAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            return _dbLocation.DeleteAsync(id.Value);
        }
    }
}
