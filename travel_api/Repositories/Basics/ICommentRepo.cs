using travel_api.ViewModels.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ICommentRepo
    {
        Task<IEnumerable<CommentVM>> GetAllCommentsAsync();
        Task<IEnumerable<CommentVM>> GetListCommentsByUserId(string userId);
        Task<CommentVM> GetCommentById(int commentId);
        Task<IEnumerable<CommentVM>> GetListCommentsByPostId(int postId);
    }
}
