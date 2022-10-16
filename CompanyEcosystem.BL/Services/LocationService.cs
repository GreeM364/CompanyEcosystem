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
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public LocationService(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var locations = _repository.GetAll();
            if(locations.Count() == 0)
                throw new ValidationException("Locations not found", "");

            return _mapper.Map<IEnumerable<Location>, List<LocationDto>>(_repository.GetAll());
        }

        public LocationDto GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");
            var location = _repository.Get(id.Value);
            if (location == null)
                throw new ValidationException("Location not found", "");

            return _mapper.Map<Location, LocationDto>(location);
        }

        public void CreateLocation(LocationDto locationDto)
        {
            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _repository.Create(location);
        }

        public void UpdateLocation(LocationDto locationDto)
        {
            var location = _mapper.Map<LocationDto, Location>(locationDto);

            _repository.Update(location);
        }

        public void DeleteLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");

            _repository.Delete(id.Value);
        }
    }
}
