using System;
using System.Collections.Generic;
using CompanyEcosystem.BL.DataTransferObjects;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface ILocationService
    {
        LocationDto GetLocation(int? id);
        Task<IEnumerable<LocationDto>> GetLocationsAsync();
        void CreateLocation(LocationDto locationDto);
        void UpdateLocation(LocationDto locationDto);
        void DeleteLocation(int? id);
    }
}
