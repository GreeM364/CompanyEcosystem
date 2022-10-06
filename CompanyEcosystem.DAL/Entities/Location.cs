using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.DAL.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Chief { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
