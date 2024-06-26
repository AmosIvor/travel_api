using travel_api.Models.EF;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ICityRepo
    {
        Task<IEnumerable<CityHasQuantityFeedbackVM>> GetCitiesHaveFeedback(string userId);
    }
}
