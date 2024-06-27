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

        public async Task<IEnumerable<PostVM>> GetPostByContentAsync(string content)
        {
            var post = await _context.Posts
                .Include(p => p.Location)
                .Include(p => p.PostMedias)
                .Include(p => p.Comments)
                .Where(p => p.PostContent.Contains(content))
                .ToListAsync();

            if (post == null)
            {
                throw new NotFoundException("Posts not found!");
            }

            var postVM = _mapper.Map<IEnumerable<PostVM>>(post);

            return postVM;
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

        public async Task<IEnumerable<PostVM>> GetTop10PostWithHighestQuantityCommentAsync()
        {
            var top10Post = await _context.Posts.OrderByDescending(x => x.Comments.Count)
                                                .Include(x => x.PostMedias)
                                                .Include(x => x.Comments)
                                                .Include(x => x.User)
                                                .Include(x => x.Location)
                                                .Take(10)
                                                .AsNoTracking()
                                                .ToListAsync();

            var top10PostResult = top10Post.Select(p =>
            {
                var postMedias = _mapper.Map<ICollection<PostMediaBaseVM>>(p.PostMedias);
                var user = _mapper.Map<UserBaseVM>(p.User);
                var location = _mapper.Map<LocationBaseVM>(p.Location);
                return new PostVM
                {
                    PostId = p.PostId,
                    PostDate = p.PostDate,
                    PostTotalLike = p.PostTotalLike,
                    PostContent = p.PostContent,
                    PostMedias = postMedias,
                    LocationId = p.LocationId,
                    Location = location,
                    UserId = p.UserId,
                    User = user,
                    CommentQuantity = p.Comments.Count
                };
            });

            var top10PostVM = _mapper.Map<IEnumerable<PostVM>>(top10PostResult);

            return top10PostVM;
        }
    }
}
