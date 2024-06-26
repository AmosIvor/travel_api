using travel_api.Models.EF;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ITravelPlanRepo
    {
        Task<TravelPlan> AddPlan(TravelPlanVM vm);

        Task<IEnumerable<TravelPlan>> GetPlans(string userId);
        Task<IEnumerable<PlanDetail>> GetPlanDetails(string planId);
    }
}
