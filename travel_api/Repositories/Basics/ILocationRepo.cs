using travel_api.ViewModels.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ILocationRepo
    {
        Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync();
    }
}
