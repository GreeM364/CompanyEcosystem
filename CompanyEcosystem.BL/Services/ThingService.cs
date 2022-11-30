using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace CompanyEcosystem.BL.Services
{
    public class ThingService : IThingService
    {
        private readonly IRepository<Thing> _repositoryThing;
        private readonly IRepository<PhotoThing> _repositoryPhoto;
        private readonly IMapper _mapper;
        public ThingService(IRepository<Thing> repositoryThing, IRepository<PhotoThing> repositoryPhoto, IMapper mapper)
        {
            _repositoryThing = repositoryThing;
            _repositoryPhoto = repositoryPhoto;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ThingDto>> GetThings()
        {
            var source = await _repositoryThing.GetAsync(includes: new List<Expression<Func<Thing, object>>>()
            {
                x => x.Photos
            });

            if (source == null || !source.Any())
                throw new ValidationException("Thing not found", "");

            var questionnaires = _mapper.Map<List<Thing>, List<ThingDto>>(source);

            return questionnaires;
        }

        public async Task<ThingDto> GetThing(int? id)
        {
            if (id == null)
                throw new ValidationException("Thing ID not set", "");

            var sourceThing = await _repositoryThing.GetByIdAsync(id.Value);
            var sourcePhotoThings = await _repositoryPhoto.GetAsync(p => p.ThingId == sourceThing.Id);

            if (sourceThing == null)
                throw new ValidationException("Thing not found", "");

            var thingsDto = _mapper.Map<Thing, ThingDto>(sourceThing);
            var photoThingDto = _mapper.Map<IEnumerable<PhotoThing>, List<PhotoThingDto>>(sourcePhotoThings);

            thingsDto.Photos = photoThingDto;

            return thingsDto;
        }

        public async Task CreateThingAsync(ThingDto thingDto, IFormFileCollection formFileCollection, string directoryPath)
        {
            var thing = _mapper.Map<ThingDto, Thing>(thingDto);
            await _repositoryThing.CreateAsync(thing);

            if (formFileCollection != null && formFileCollection.Any() && !string.IsNullOrWhiteSpace(directoryPath))
            {
                directoryPath = Path.Combine(directoryPath, thing.Id.ToString());

                if (!Directory.Exists(directoryPath))
                {
                    var dirInfo = new DirectoryInfo(directoryPath);
                    dirInfo.Create();
                }
            }

            foreach (var uploadedImage in formFileCollection)
            {

                var path = $"/img/things/{thingDto.Id}/{uploadedImage.FileName}";

                using (var fileStream = new FileStream(Path.Combine(directoryPath, uploadedImage.FileName), FileMode.Create))
                {
                    uploadedImage.CopyToAsync(fileStream);
                }

                var photo = _mapper.Map<PhotoThingDto, PhotoThing>(new PhotoThingDto { ThingId = thing.Id, Path = path });
                await _repositoryPhoto.CreateAsync(photo);
            }
        }

        public async Task UpdateThingAsync(ThingDto thingDto, IFormFileCollection formFileCollection, string directoryPath)
        {
            var thing = _mapper.Map<ThingDto, Thing>(thingDto);
            await _repositoryThing.UpdateAsync(thing);

            if (formFileCollection != null && formFileCollection.Any() && !string.IsNullOrWhiteSpace(directoryPath))
            {
                directoryPath = Path.Combine(directoryPath, thing.Id.ToString());

                if (!Directory.Exists(directoryPath))
                {
                    var dirInfo = new DirectoryInfo(directoryPath);
                    dirInfo.Create();
                }
            }

            foreach (var uploadedImage in formFileCollection)
            {

                var path = $"/img/things/{thingDto.Id}/{uploadedImage.FileName}";

                using (var fileStream = new FileStream(Path.Combine(directoryPath, uploadedImage.FileName), FileMode.Create))
                {
                    uploadedImage.CopyToAsync(fileStream);
                }

                var photo = _mapper.Map<PhotoThingDto, PhotoThing>(new PhotoThingDto { ThingId = thing.Id, Path = path });
                await _repositoryPhoto.UpdateAsync(photo);
            }
        }

        public Task DeleteThingAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Thing ID not set", "");

            return _repositoryThing.DeleteAsync(id.Value);
        }
    }
}
