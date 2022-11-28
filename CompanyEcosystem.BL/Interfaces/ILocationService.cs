using System;
using System.Collections.Generic;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDto> GetLocationAsync(int? id);
        Task<List<LocationDto>> GetLocationsAsync();
        Task CreateLocationAsync(LocationDto locationDto, IFormFile formFile, string directoryPath);
        Task UpdateLocationAsync(LocationDto locationDto, IFormFile formFile, string directoryPath);
        Task DeleteLocationAsync(int? id);
    }
}
