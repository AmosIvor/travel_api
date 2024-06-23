using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ILocationRepo
    {
        Task<LocationVM> GetLocationByIdAsync(int locationId);
        Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync();

        Task<IEnumerable<PlaceResponseVM>> GetLocationOrCityBySearchAsync(string search);
    }
}
