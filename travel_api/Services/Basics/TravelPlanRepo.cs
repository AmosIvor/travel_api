using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class TravelPlanRepo : ITravelPlanRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TravelPlanRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanDetailVM>> GetPlanDetailByTravelPlanIdAsync(int travelPlanId)
        {
            var planDetail = await _context.PlanDetails.Where(x => x.TravelPlanId == travelPlanId)
                                                         .Include(x => x.Location)
                                                         .AsNoTracking()
                                                         .ToListAsync();

            var planDetailMap = _mapper.Map<IEnumerable<PlanDetailVM>>(planDetail);

            return planDetailMap;
        }

        public async Task<TravelPlanVM> GetTravelPlanByIdAsync(int travelPlanId)
        {
            var travelPlan = await _context.TravelPlans.Where(x => x.TravelPlanId == travelPlanId)
                                                       .Include(x => x.User)
                                                       .Include(x => x.PlanDetails)
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync();

            var travelPlanMap = _mapper.Map<TravelPlanVM>(travelPlan);

            return travelPlanMap;
        }

        public async Task<IEnumerable<TravelPlanVM>> GetTravelPlansAsync()
        {
            var travelPlans = await _context.TravelPlans.OrderByDescending(x => x.PlanCreateAt)
                                                        .Include(x => x.User)
                                                        .AsNoTracking()
                                                        .ToListAsync();

            var travelPlansMap = _mapper.Map<IEnumerable<TravelPlanVM>>(travelPlans);

            return travelPlansMap;
        }

        public async Task<IEnumerable<TravelPlanVM>> GetTravelPlansByUserIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var travelPlans = await _context.TravelPlans.Where(x => x.UserId == userId)
                                                        .OrderByDescending(x => x.PlanCreateAt)
                                                        .Include(x => x.User)
                                                        .AsNoTracking()
                                                        .ToListAsync();

            var travelPlansMap = _mapper.Map<IEnumerable<TravelPlanVM>>(travelPlans);

            return travelPlansMap;
        }
    }
}
