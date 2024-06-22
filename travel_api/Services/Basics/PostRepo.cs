using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class PostRepo : IPostRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostVM>> GetAllPostsAsync()
        {
            var posts = await _context.Posts
                              .Include(p => p.Location)
                              .Include(p => p.PostMedias)
                              .Include(p => p.Comments)
                              .Include(p => p.User)
                              .OrderByDescending(p => p.PostDate)
                              .ToListAsync();

            var postsVM = _mapper.Map<IEnumerable<PostVM>>(posts);

            return postsVM;
        }

        public async Task<IEnumerable<PostVM>> GetListPostsByUserIdAsync(string userId)
        {
            var posts = await _context.Posts
                                    .Include(p => p.Location)
                                    .Include(p => p.PostMedias)
                                    .Include(p => p.Comments)
                                    .Where(p => p.UserId == userId)
                                    .OrderByDescending(p => p.PostDate)
                                    .ToListAsync();

            // mapper
            var postsVM = _mapper.Map<IEnumerable<PostVM>>(posts);

            return postsVM;
        }

        public async Task<PostVM> GetPostByIdAsync(int postId)
        {
            // find post
            var post = await _context.Posts
                                    .Include(p => p.Location)
                                    .Include(p => p.PostMedias)
                                    .Include(p => p.Comments)
                                    .Include(p => p.User)
                                    .SingleOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                throw new NotFoundException("Post not found");
            }

            var postVM = _mapper.Map<PostVM>(post);

            return postVM;
        }
    }
}
