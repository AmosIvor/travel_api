using Microsoft.AspNetCore.Mvc;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly ITravelPlanRepo _service;

        public TravelPlanController(ITravelPlanRepo service)
        {
            _service = service;
        }

        [HttpPost("new-plan")]
        public async Task<IActionResult> NewPlan(TravelPlanVM vm)
        {
            return Ok(await _service.AddPlan(vm));
        }

        [HttpGet("get-plans/{userId}")]
        public async Task<IActionResult> GetPlans(string userId)
        {
            return Ok(await _service.GetPlans(userId));
        }

        [HttpGet("get-plan-details")]
        public async Task<IActionResult> GetPlanDetails(string planId)
        {
            return Ok(await _service.GetPlanDetails(planId));
        }
    }
}
