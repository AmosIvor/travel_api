using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly IBaseRepo<TravelPlan, TravelPlanVM, TravelPlanRequest, int> _baseRepo;
        private readonly ITravelPlanRepo _travelPlanRepo;
        public TravelPlanController(IBaseRepo<TravelPlan, TravelPlanVM, TravelPlanRequest, int> baseRepo, ITravelPlanRepo travelPlanRepo)
        {
            _baseRepo = baseRepo;
            _travelPlanRepo = travelPlanRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravelPlan(TravelPlanRequest travelPlanVM)
        {
            var travelPlanVMResult = await _baseRepo.AddAsync(travelPlanVM);

            return Ok(new SuccessResponseVM<TravelPlanVM>()
            {
                Message = "Create new travel plan successfully",
                Data = travelPlanVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTravelPlan(TravelPlanRequest travelPlanVM)
        {
            var travelPlanVMResult = await _baseRepo.UpdateAsync(travelPlanVM);

            return Ok(new SuccessResponseVM<TravelPlanVM>()
            {
                Message = "Update travel plan successfully",
                Data = travelPlanVMResult
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTravelPlans()
        {
            var travelPlansVMResult = await _travelPlanRepo.GetTravelPlansAsync();

            return Ok(new SuccessResponseVM<IEnumerable<TravelPlanVM>>()
            {
                Message = "Get list travel plan successfully",
                Data = travelPlansVMResult
            });
        }

        [HttpGet("{userId}/travel-plans")]
        public async Task<IActionResult> GetTravelPlansByUserId(string userId)
        {
            var travelPlansVMResult = await _travelPlanRepo.GetTravelPlansByUserIdAsync(userId);

            return Ok(new SuccessResponseVM<IEnumerable<TravelPlanVM>>()
            {
                Message = "Get list travel plan by user successfully",
                Data = travelPlansVMResult
            });
        }

        [HttpGet("{travelPlanId}/plan-detail")]
        public async Task<IActionResult> GetPlanDetailByTravelPlanId(int travelPlanId)
        {
            var planDetailsVMResult = await _travelPlanRepo.GetPlanDetailByTravelPlanIdAsync(travelPlanId);

            return Ok(new SuccessResponseVM<IEnumerable<PlanDetailVM>>()
            {
                Message = "Get list plan detail by travel plan successfully",
                Data = planDetailsVMResult
            });
        }

        [HttpGet("{travelPlanId}")]
        public async Task<IActionResult> GetTravelPlanByIdAsync(int travelPlanId)
        {
            var travelPlanVMResult = await _travelPlanRepo.GetTravelPlanByIdAsync(travelPlanId);

            return Ok(new SuccessResponseVM<TravelPlanVM>()
            {
                Message = "Get travel plan by id successfully",
                Data = travelPlanVMResult
            });
        }
    }
}
