using CompanyEcosystem.DAL.EF;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.Repositories
{
    public class PhotoThingRepository : IRepository<PhotoThing>
    {
        private readonly CompanyEcosystemContext _db;
        public PhotoThingRepository(CompanyEcosystemContext context)
        {
            _db = context;
        }

        public IEnumerable<PhotoThing> GetAll()
        {
            return _db.PhotoThings;
        }

        public PhotoThing Get(int id)
        {
            return _db.PhotoThings.Find(id);
        }

        public void Create(PhotoThing item)
        {
            _db.PhotoThings.Add(item);
            _db.SaveChanges();
        }

        public void Update(PhotoThing item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var photo = _db.PhotoThings.Find(id);
            _db.PhotoThings.Remove(photo);

            _db.SaveChanges();
        }
    }
}
