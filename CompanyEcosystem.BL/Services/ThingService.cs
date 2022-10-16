using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;

namespace CompanyEcosystem.BL.Services
{
    public class ThingService : IThingService
    {
        private readonly IRepository<Thing> _repository;
        private readonly IMapper _mapper;
        public ThingService(IRepository<Thing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ThingDto> GetThings()
        {
            var things = _repository.GetAll();
            if (things.Count() == 0)
                throw new ValidationException("Things not found", "");

            return _mapper.Map<IEnumerable<Thing>, List<ThingDto>>(_repository.GetAll());
        }

        public ThingDto GetThing(int? id)
        {
            if (id == null)
                throw new ValidationException("Thing ID not set", "");
            var thing = _repository.Get(id.Value);
            if (thing == null)
                throw new ValidationException("Thing not found", "");

            return _mapper.Map<Thing, ThingDto>(thing);
        }

        public void CreateThing(ThingDto thingDto)
        {
            var thing = _mapper.Map<ThingDto, Thing>(thingDto);

            _repository.Create(thing);
        }

        public void UpdateThing(ThingDto thingDto)
        {
            var thing = _mapper.Map<ThingDto, Thing>(thingDto);

            _repository.Update(thing);
        }

        public void DeleteThing(int? id)
        {
            if (id == null)
                throw new ValidationException("Thing ID not set", "");

            _repository.Delete(id.Value);
        }
    }
}
