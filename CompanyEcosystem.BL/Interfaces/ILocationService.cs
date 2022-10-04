using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.Data_Transfer_Object;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface ILocationService
    {
        LocationDTO GetLocation(int? id);
        IEnumerable<LocationDTO> GetLocations();
    }
}
