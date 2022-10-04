using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.EF
{
    public class CompanyEcosystemContext : DbContext
    {
        public CompanyEcosystemContext(DbContextOptions<CompanyEcosystemContext> connectionString)
            : base(connectionString)
        {
        }
    }
}
