using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class CommentRepo : ICommentRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CommentRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentVM>> GetAllCommentsAsync()
        {
            var comments = await _context.Comments
                              .Include(c => c.CommentMedias)
                              .OrderByDescending(c => c.CommentDate)
                              .ToListAsync();

            var commentsVM = _mapper.Map<IEnumerable<CommentVM>>(comments);

            return commentsVM;
        }

        public async Task<IEnumerable<CommentVM>> GetListCommentsByUserIdAsync(string userId)
        {
            var comments = await _context.Comments
                                    .Include(c => c.CommentMedias)
                                    .Where(c => c.UserId == userId)
                                    .OrderByDescending(c => c.CommentDate)
                                    .ToListAsync();

            // mapper
            var commentsVM = _mapper.Map<IEnumerable<CommentVM>>(comments);

            return commentsVM;
        }

        public async Task<CommentVM> GetCommentByIdAsync(int commentId)
        {
            // find comment
            var comment = await _context.Comments
                                    .Include(c => c.CommentMedias)
                                    .SingleOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
            {
                throw new NotFoundException("Comment cannot found");
            }

            var commentVM = _mapper.Map<CommentVM>(comment);

            return commentVM;
        }

        public async Task<IEnumerable<CommentVM>> GetListCommentsByPostIdAsync(int postId)
        {
            var comments = await _context.Comments
                                    .Include(c => c.CommentMedias)
                                    .Where(c => c.PostId == postId)
                                    .OrderByDescending(c => c.CommentDate)
                                    .ToListAsync();

            // mapper
            var commentsVM = _mapper.Map<IEnumerable<CommentVM>>(comments);

            return commentsVM;
        }
    }
}
