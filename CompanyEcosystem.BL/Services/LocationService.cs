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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Location>, List<LocationDTO>>(_repository.GetAll());
        }
        public LocationDTO GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");
            var location = _repository.Get(id.Value);
            if (location == null)
                throw new ValidationException("Location not found", "");

            return new LocationDTO { Id = location.Id, Title = location.Title, Chief = location.Chief, 
                WorkingStart = location.WorkingStart, WorkingEnd = location.WorkingEnd};
        }

        public void PostLocation(LocationDTO locationDto)
        {
            var location = _mapper.Map<LocationDTO, Location>(locationDto);

            _repository.Create(location);
        }
    }
}
