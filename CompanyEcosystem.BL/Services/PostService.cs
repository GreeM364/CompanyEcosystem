using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;

namespace CompanyEcosystem.BL.Services
{
    public class PostService : IPostService
    {
        public readonly IRepository<Post> _dbPost;
        public readonly IRepository<Location> _dbLocation;
        public readonly IMapper _mapper;
        public PostService(IRepository<Post> dbPost, IRepository<Location> dbLocation, IMapper mapper)
        {
            _dbPost = dbPost;
            _dbLocation = dbLocation;
            _mapper = mapper;
        }


        public async Task<List<PostDto>> GetPostsAsync()
        {
            var source = await _dbPost.GetAllAsync();

            if (source == null || !source.Any())
                throw new ValidationException("Post not found", "");

            var posts = _mapper.Map<List<Post>, List<PostDto>>(source);

            return posts;
        }

        public async Task<PostDto> GetPostAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Post ID not set", "");

            var source = await _dbPost.GetByIdAsync(id.Value);

            if (source == null)
                throw new ValidationException("Post not found", "");

            var postDto = _mapper.Map<Post, PostDto>(source);

            return postDto;
        }

        public async Task CreatePostAsync(PostDto postDto)
        {
            var location = await _dbLocation.GetByIdAsync(postDto.LocationId);
            if (location == null)
                throw new ValidationException("Location not found", "");

            var post = _mapper.Map<PostDto, Post>(postDto);
            post.Create = DateTime.Now;

            await _dbPost.CreateAsync(post);
        }

        public async Task UpdatePostAsync(PostDto postDto)
        {
            var location = await _dbLocation.GetByIdAsync(postDto.LocationId);
            if (location == null)
                throw new ValidationException("Location not found", "");

            var post = _mapper.Map<PostDto, Post>(postDto);

            await _dbPost.UpdateAsync(post);
        }

        public Task DeletePostAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Post ID not set", "");

            return _dbPost.DeleteAsync(id.Value);
        }
    }
}
