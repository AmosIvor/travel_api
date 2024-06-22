using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ILocationRepo
    {
        Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync();
    }
}
