using travel_api.ViewModels.EFViewModel;

namespace travel_api.Repositories
{
    public interface IUserRepo
    {
        Task<ICollection<UserVM>> GetUsersAsync();
    }
}
