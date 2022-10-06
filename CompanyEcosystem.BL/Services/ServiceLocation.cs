using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;

namespace CompanyEcosystem.BL.Services
{
    public class ServiceLocation : ILocationService
    {
        private readonly IRepository<Location> Repository;

        public ServiceLocation(IRepository<Location> repository)
        {
            Repository = repository;
        }
        public IEnumerable<LocationDTO> GetLocations()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Location>, List<LocationDTO>>(Repository.GetAll());
        }
        public LocationDTO GetLocation(int? id)
        {
            if (id == null)
                throw new ValidationException("Location ID not set", "");
            var location = Repository.Get(id.Value);
            if (location == null)
                throw new ValidationException("Location not found", "");

            return new LocationDTO { Id = location.Id, Title = location.Title, Chief = location.Chief, 
                WorkingStart = location.WorkingStart, WorkingEnd = location.WorkingEnd};
        }
    }
}
