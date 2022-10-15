using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.Data_Transfer_Object;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IThingService
    {
        ThingDTO GetThing(int? id);
        IEnumerable<ThingDTO> GetThings();
        void CreateThing(ThingDTO thingDto);
        void UpdateThing(ThingDTO thingDto);
        void DeleteThing(int? id);
    }
}
