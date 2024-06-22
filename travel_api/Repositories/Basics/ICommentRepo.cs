using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ICommentRepo
    {
        Task<IEnumerable<CommentVM>> GetAllCommentsAsync();
        Task<IEnumerable<CommentVM>> GetListCommentsByUserIdAsync(string userId);
        Task<CommentVM> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<CommentVM>> GetListCommentsByPostIdAsync(int postId);
    }
}
