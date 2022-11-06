using CompanyEcosystem.BL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPostAsync(int? id);
        Task<List<PostDto>> GetPostsAsync();
        Task CreatePostAsync(PostDto postDto);
        Task UpdatePostAsync(PostDto postDto);
        Task DeletePostAsync(int? id);
    }
}
