using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var source = await _postService.GetPostsAsync();

                var posts = _mapper.Map<List<PostDto>, List<PostViewModel>>(source);

                return Ok(posts);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var source = await _postService.GetPostAsync(id);

                var post = _mapper.Map<PostDto, PostViewModel>(source);

                return Ok(post);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var postDto = _mapper.Map<PostCreateUpdateViewModel, PostDto>(model);

                await _postService.CreatePostAsync(postDto);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PostCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var postDto = _mapper.Map<PostCreateUpdateViewModel, PostDto>(model);

                await _postService.UpdatePostAsync(postDto);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _postService.DeletePostAsync(id);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
