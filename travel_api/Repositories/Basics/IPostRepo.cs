using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IPostRepo
    {
        Task<IEnumerable<PostVM>> GetAllPostsAsync();
        Task<IEnumerable<PostVM>> GetListPostsByUserIdAsync(string userId);
        Task<PostVM> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostVM>> GetPostByContentAsync(string content);
    }
}
