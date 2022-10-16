using CompanyEcosystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.EF
{
    public class CompanyEcosystemContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<PhotoThing> PhotoThings { get; set; }
        public CompanyEcosystemContext(DbContextOptions<CompanyEcosystemContext> connectionString)
            : base(connectionString)
        {
        }
    }
}
