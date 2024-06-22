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
    public class FeedbackController : ControllerBase
    {
        private readonly IBaseRepo<Feedback, FeedbackVM, FeedbackRequest, int> _baseRepo;
        private readonly IFeedbackRepo _feedbackRepo;
        public FeedbackController(IBaseRepo<Feedback, FeedbackVM, FeedbackRequest, int> baseRepo, IFeedbackRepo feedbackRepo)
        {
            _baseRepo = baseRepo;
            _feedbackRepo = feedbackRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            var feedbacksVM = await _feedbackRepo.GetAllFeedbacksAsync();

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackVM>>()
            {
                Message = "Get all feedbacks successfully",
                Data = feedbacksVM
            });
        }

        [HttpGet("{feedbackId}")]
        public async Task<IActionResult> GetFeedbackById(int feedbackId)
        {
            var feedbackVMResult = await _feedbackRepo.GetFeedbackByIdAsync(feedbackId);

            return Ok(new SuccessResponseVM<FeedbackVM>()
            {
                Message = "Get feedback by id successfully",
                Data = feedbackVMResult
            });
        }

        [HttpGet("{userId}/feedbacks")]
        public async Task<IActionResult> GetListFeedbacksByUserId(string userId)
        {
            var feedbacksVM = await _feedbackRepo.GetListFeedbacksByUserIdAsync(userId);

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackVM>>()
            {
                Message = "Get list feedback by user successfully",
                Data = feedbacksVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(FeedbackRequest feedbackVM)
        {
            var feedbackVMResult = await _baseRepo.AddAsync(feedbackVM);

            return Ok(new SuccessResponseVM<FeedbackVM>()
            {
                Message = "Create new feedback successfully",
                Data = feedbackVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeedback(FeedbackRequest feedbackVM)
        {
            var feedbackVMResult = await _baseRepo.UpdateAsync(feedbackVM);

            return Ok(new SuccessResponseVM<FeedbackVM>()
            {
                Message = "Update feedback successfully",
                Data = feedbackVMResult
            });
        }

        [HttpDelete("{feedbackId}")]
        public async Task<IActionResult> UpdateFeedback(int feedbackId)
        {
            var feedbackVMResult = await _baseRepo.DeleteAsync(feedbackId);

            return Ok(new SuccessResponseVM<FeedbackVM>()
            {
                Message = "Delete feedback successfully",
                Data = feedbackVMResult
            });
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFeedbacksByFilter([FromQuery] decimal rating = 5, [FromQuery] int timeFeedbackType = 0, [FromQuery] int tripType = 0)
        {
            var listFeedbackByFilterVM = await _feedbackRepo.GetFeedbacksByFilterAsync(rating, timeFeedbackType, tripType);

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackVM>>()
            {
                Message = "Get feedbacks by filter successfully",
                Data = listFeedbackByFilterVM
            });
        }
    }
}
