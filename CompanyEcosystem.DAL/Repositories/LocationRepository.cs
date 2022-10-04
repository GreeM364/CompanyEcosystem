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
        private CompanyEcosystemContext db;
        public LocationRepository(CompanyEcosystemContext context)
        {
            db = context;
        }
        public IEnumerable<Location> GetAll()
        {
            return db.Locations;
        }

        public Location Get(int id)
        {
            return db.Locations.Find(id);
        }

        public void Create(Location item)
        {
            db.Locations.Add(item);
        }

        public void Update(Location item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var location = db.Locations.Find(id);
            
            if (location != null)
                db.Locations.Remove(location);
        }
    }
}
