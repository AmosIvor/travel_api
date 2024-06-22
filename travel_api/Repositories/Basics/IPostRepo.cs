using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IPostRepo
    {
        Task<IEnumerable<PostVM>> GetAllPostsAsync();
        Task<IEnumerable<PostVM>> GetListPostsByUserId(string userId);
        Task<PostVM> GetPostById(int postId);
    }
}
