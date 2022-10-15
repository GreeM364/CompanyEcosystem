using System;
using System.Collections.Generic;
using CompanyEcosystem.BL.Data_Transfer_Object;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface ILocationService
    {
        LocationDTO GetLocation(int? id);
        IEnumerable<LocationDTO> GetLocations();
        void CreateLocation(LocationDTO locationDto);
        void UpdateLocation(LocationDTO locationDto);
        void DeleteLocation(int? id);
    }
}
