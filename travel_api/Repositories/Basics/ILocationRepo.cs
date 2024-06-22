using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ILocationRepo
    {
        Task<LocationVM> GetLocationByIdAsync(int locationId);
        Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync();
    }
}
