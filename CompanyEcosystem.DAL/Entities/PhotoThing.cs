using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.DAL.Entities
{
    public class PhotoThing
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ThingId { get; set; }
        public Thing Thing { get; set; }
    }
}
