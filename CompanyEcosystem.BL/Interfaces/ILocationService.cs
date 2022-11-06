using System;
using System.Collections.Generic;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDto> GetLocationAsync(int? id);
        Task<List<LocationDto>> GetLocationsAsync();
        Task CreateLocationAsync(LocationDto locationDto);
        Task UpdateLocationAsync(LocationDto locationDto);
        Task DeleteLocationAsync(int? id);
    }
}
