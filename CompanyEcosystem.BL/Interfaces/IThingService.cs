using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IThingService
    {
        ThingDto GetThing(int? id);
        IEnumerable<ThingDto> GetThings();
        void CreateThing(ThingDto thingDto, IFormFileCollection formFileCollection, string directoryPath);
        void UpdateThing(ThingDto thingDto);
        void DeleteThing(int? id);
    }
}
