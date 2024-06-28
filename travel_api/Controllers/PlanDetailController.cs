using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories.Basics;
using travel_api.Repositories;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;
using travel_api.Services.Basics;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanDetailController : ControllerBase
    {
        private readonly IBaseRepo<PlanDetail, PlanDetailVM, PlanDetailRequest, int> _baseRepo;
        private readonly IPlanDetailRepo _planDetailRepo;
        public PlanDetailController(IBaseRepo<PlanDetail, PlanDetailVM, PlanDetailRequest, int> baseRepo, IPlanDetailRepo planDetailRepo)
        {
            _baseRepo = baseRepo;
            _planDetailRepo = planDetailRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanDetail(PlanDetailRequest planDetailVM)
        {
            var planDetailVMResult = await _baseRepo.AddAsync(planDetailVM);

            return Ok(new SuccessResponseVM<PlanDetailVM>()
            {
                Message = "Create new plan detail successfully",
                Data = planDetailVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlanDetail(PlanDetailRequest planDetailVM)
        {
            var planDetailVMResult = await _baseRepo.UpdateAsync(planDetailVM);

            return Ok(new SuccessResponseVM<PlanDetailVM>()
            {
                Message = "Update plan detail successfully",
                Data = planDetailVMResult
            });
        }

        [HttpGet("{planDetailId}")]
        public async Task<IActionResult> GetPlanDetailByUserId(int planDetailId)
        {
            var planDetailVM = await _planDetailRepo.GetPlanDetailByIdAsync(planDetailId);

            return Ok(new SuccessResponseVM<PlanDetailVM>()
            {
                Message = "Get plan detail by id successfully",
                Data = planDetailVM
            });
        }

        [HttpGet("{locationId}/plan-details")]
        public async Task<IActionResult> GetPlanDetailsByLocationId(int locationId)
        {
            var plansDetailVM = await _planDetailRepo.GetPlanDetailsByLocationIdAsync(locationId);

            return Ok(new SuccessResponseVM<IEnumerable<PlanDetailVM>>()
            {
                Message = "Get list plan detail by location successfully",
                Data = plansDetailVM
            });
        }
    }
}
