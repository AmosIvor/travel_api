using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IPlanDetailRepo
    {
        Task<PlanDetailVM> GetPlanDetailByIdAsync(int planDetailId);
        Task<IEnumerable<PlanDetailVM>> GetPlanDetailsByLocationIdAsync(int locationId);
    }
}
