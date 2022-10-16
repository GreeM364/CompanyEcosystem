using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using CompanyEcosystem.BL.DataTransferObjects;
=======
using CompanyEcosystem.BL.Data_Transfer_Object;
using Microsoft.AspNetCore.Http;
>>>>>>> Test

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IThingService
    {
<<<<<<< HEAD
        ThingDto GetThing(int? id);
        IEnumerable<ThingDto> GetThings();
        void CreateThing(ThingDto thingDto);
        void UpdateThing(ThingDto thingDto);
=======
        ThingDTO GetThing(int? id);
        IEnumerable<ThingDTO> GetThings();
        void CreateThing(ThingDTO thingDto, IFormFileCollection formFileCollection, string directoryPath);
        void UpdateThing(ThingDTO thingDto);
>>>>>>> Test
        void DeleteThing(int? id);
    }
}
