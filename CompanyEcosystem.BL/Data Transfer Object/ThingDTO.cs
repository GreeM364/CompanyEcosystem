using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.BL.Data_Transfer_Object
{
    public class ThingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }

        public int LocationId { get; set; }
    }
}
