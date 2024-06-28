using travel_api.Models.EF;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ITravelPlanRepo
    {
        Task<IEnumerable<TravelPlanVM>> GetTravelPlansAsync();
        Task<IEnumerable<TravelPlanVM>> GetTravelPlansByUserIdAsync(string userId);
        Task<IEnumerable<PlanDetailVM>> GetPlanDetailByTravelPlanIdAsync(int travelPlanId);
        Task<TravelPlanVM> GetTravelPlanByIdAsync(int travelPlanId);
    }
}
