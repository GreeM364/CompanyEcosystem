using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.DAL.EF;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly CompanyEcosystemContext _db;
        public LocationRepository(CompanyEcosystemContext context)
        {
            _db = context;
        }
        public IEnumerable<Location> GetAll()
        {
            return _db.Locations;
        }

        public Location Get(int? id)
        {
            return _db.Locations.Find(id);
        }

        public void Create(Location item)
        {
            _db.Locations.Add(item);
            _db.SaveChanges();
        }

        public void Update(Location item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var location = _db.Locations.Find(id);
            _db.Locations.Remove(location);

            _db.SaveChanges();
        }
    }
}
