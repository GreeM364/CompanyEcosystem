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
        Task<ThingDto> GetThing(int? id);
        Task<IEnumerable<ThingDto>> GetThings();
        Task CreateThingAsync(ThingDto thingDto, IFormFileCollection formFileCollection, string directoryPath);
        Task UpdateThingAsync(ThingDto thingDto, IFormFileCollection formFileCollection, string directoryPath);
        Task DeleteThingAsync(int? id);
    }
}
