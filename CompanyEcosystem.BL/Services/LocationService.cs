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
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public LocationService(IRepository<Location> dbLocation, IRepository<Employee> dbEmployee, IAccountService accountService, IMapper mapper)
        {
            _dbLocation = dbLocation;
            _dbEmployee = dbEmployee;
            _accountService = accountService;
            _mapper = mapper;
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var employees = _accountService.GetAll();

            var locations = _dbLocation.GetAll().Select(c => new LocationDto()
            {
                Id = c.Id,
                Title = c.Title,
                ChiefEmail = employees.FirstOrDefault(e => e.Id == c.Chief).Email, 
                WorkingStart = c.WorkingStart,
                WorkingEnd = c.WorkingEnd,
                Employees = employees.Where(e => e.LocationId == c.Id)
            }); //TODO: шо це в загалі за помилка

            if (locations == null)
                throw new ValidationException("Locations not found", "");

            return locations;
        }

        public LocationDto GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            var location = _dbLocation.Get(id.Value);

            if (location == null)
                throw new ValidationException("Location not found", "");

            var locationDto = new LocationDto() 
            {
                Id = location.Id,
                Title = location.Title,
                ChiefEmail = _accountService.GetById(location.Chief).Email,
                WorkingStart = location.WorkingStart,
                WorkingEnd = location.WorkingEnd,
                Employees = _accountService.GetAll().Where(e => e.LocationId == location.Id)
            };

            return locationDto;
        }

        public void CreateLocation(LocationDto locationDto)
        {
            var chief = _dbEmployee.Get(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _dbLocation.Create(location);
        }

        public void UpdateLocation(LocationDto locationDto)
        {
            var chief = _dbEmployee.Get(locationDto.Chief);
            if (chief == null)
                throw new ValidationException("Chief not found", "");

            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _dbLocation.Update(location);
        }

        public void DeleteLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            _dbLocation.Delete(id.Value);
        }
    }
}
