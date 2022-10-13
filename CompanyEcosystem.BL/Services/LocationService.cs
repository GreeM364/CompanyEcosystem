using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
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

        public IEnumerable<LocationDTO> GetLocations()
        {
            var locations = _repository.GetAll();
            if(locations.Count() == 0)
                throw new ValidationException("Locations not found", "");

            return _mapper.Map<IEnumerable<Location>, List<LocationDTO>>(_repository.GetAll());
        }

        public LocationDTO GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");
            var location = _repository.Get(id.Value);
            if (location == null)
                throw new ValidationException("Location not found", "");

            return _mapper.Map<Location, LocationDTO>(location);
        }

        public void CreateLocation(LocationDTO locationDto)
        {
            var location = _mapper.Map<LocationDTO, Location>(locationDto);

            _repository.Create(location);
        }

        public void UpdateLocation(LocationDTO locationDto)
        {
            var location = _mapper.Map<LocationDTO, Location>(locationDto);

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
