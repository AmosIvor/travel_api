using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class TravelPlanRepo : ITravelPlanRepo
    {
        private readonly DataContext _context;

        public TravelPlanRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<TravelPlan> AddPlan(TravelPlanVM vm)
        {
            var travelPlan = new TravelPlan
            {
                PlanId = Guid.NewGuid().ToString(),
                PlanName = vm.PlanName,
                CreateTime = DateTime.Now,
            };

            _context.Add(travelPlan);
            await _context.SaveChangesAsync();

            if (vm.PlanDetails != null)
            {
                foreach (var d in vm.PlanDetails)
                {
                    _context.PlanDetails.Add(new PlanDetail
                    {
                        PlanId = travelPlan.PlanId,
                        LocationId = d.LocationId,
                    });
                }

                await _context.SaveChangesAsync();
            }

            return travelPlan;
        }

        public async Task<IEnumerable<TravelPlan>> GetPlans(string userId)
        {
            var plans = await _context.TravelPlans
                .Where(p => p.UserId == userId)
                .ToListAsync();

            return plans;
        }

        async Task<IEnumerable<PlanDetail>> ITravelPlanRepo.GetPlanDetails(string planId)
        {
            return await _context.PlanDetails
                .Where(d => d.PlanId == planId)
                .ToListAsync();
        }
    }
}
