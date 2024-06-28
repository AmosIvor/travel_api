using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class PlanDetailRepo : IPlanDetailRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlanDetailRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlanDetailVM> GetPlanDetailByIdAsync(int planDetailId)
        {
            var planDetail = await _context.PlanDetails.Where(x => x.PlanDetailId == planDetailId)
                                                       .Include(x => x.Location)
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync();

            if (planDetail == null)
            {
                throw new NotFoundException("Plan Detail not found");
            }

            var planDetailVM = _mapper.Map<PlanDetailVM>(planDetail);

            return planDetailVM;
        }

        public async Task<IEnumerable<PlanDetailVM>> GetPlanDetailsByLocationIdAsync(int locationId)
        {
            var plansDetail = await _context.PlanDetails.Where(x => x.LocationId == locationId)
                                                       .Include(x => x.Location)
                                                       .AsNoTracking()
                                                       .ToListAsync();

            var plansDetailVM = _mapper.Map<IEnumerable<PlanDetailVM>>(plansDetail);

            return plansDetailVM;
        }
    }
}
