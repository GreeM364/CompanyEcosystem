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
            var locations = (await _dbLocation.GetAllAsync()).Select(async c => new LocationDto()
            {
                Id = c.Id,
                Title = c.Title,
                ChiefEmail = (await _dbEmployee.GetByIdAsync(c.Chief)).Email, 
                WorkingStart = c.WorkingStart,
                WorkingEnd = c.WorkingEnd,
                Employees = await _dbEmployee.GetAsync(e => e.LocationId == c.Id)
            });

            if (locations == null)
                throw new ValidationException("Locations not found", "");

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
                Title = location.Result.Title,
                ChiefEmail = _dbEmployee.GetByIdAsync(location.Result.Chief).Result.Email,
                WorkingStart = location.Result.WorkingStart,
                WorkingEnd = location.Result.WorkingEnd,
                Employees = _dbEmployee.GetAsync(l => l.Id == location.Result.Id).Result
            };

            return locationDto;
        }

        public void CreateLocation(LocationDto locationDto)
        {
            var chief = _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _dbLocation.CreateAsync(location);
        }

        public void UpdateLocation(LocationDto locationDto)
        {
            var chief = _dbEmployee.GetByIdAsync(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _dbLocation.UpdateAsync(location);
        }

        public void DeleteLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            _dbLocation.DeleteAsync(id.Value);
        }
    }
}
