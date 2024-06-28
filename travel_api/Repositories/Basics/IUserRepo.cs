using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IUserRepo
    {
        Task<ICollection<UserVM>> GetUsersAsync();
        Task<UserVM> GetUserByIdAsync(string userId);
        Task<UserVM> UpdateUserAsync(UserUpdateRequest req);
        Task<IEnumerable<UserBaseVM>> SearchUsersByUserNameAsync(string userNameSearchString);
    }
}
