using System;
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
    public class EmployeeRepository : IRepository<Employee>
    {
        private CompanyEcosystemContext db;
        public EmployeeRepository(CompanyEcosystemContext context)
        {
            db = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Locations.Find(id);

            if (user != null)
                db.Locations.Remove(user);

            db.SaveChanges();
        }
    }
}
