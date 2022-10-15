using CompanyEcosystem.DAL.EF;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.Repositories
{
    public class ThingRepository : IRepository<Thing>
    {
        private readonly CompanyEcosystemContext _db;

        public ThingRepository(CompanyEcosystemContext context)
        {
            _db = context;
        }
        public IEnumerable<Thing> GetAll()
        {
            return _db.Things;
        }

        public Thing Get(int id)
        {
            return _db.Things.Find(id);
        }

        public void Create(Thing item)
        {
            _db.Things.Add(item);
            _db.SaveChanges();
        }

        public void Update(Thing item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var thing = _db.Things.Find(id);
            _db.Things.Remove(thing);

            _db.SaveChanges();
        }
    }
}
