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
        private readonly IFeedbackRepo _feedbackRepo;
        private readonly IBaseRepo<Feedback, FeedbackVM, FeedbackRequest, int> _baseRepo;

        public FeedbackController(IBaseRepo<Feedback, FeedbackVM, FeedbackRequest, int> baseRepo, IFeedbackRepo feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
            _baseRepo = baseRepo;
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

        [HttpPost("add-to-db")]
        public async Task<IActionResult> CreateFeedback(FeedbackRequest feedbackVM)
        {
            var feedbackVMResult = await _baseRepo.AddAsync(feedbackVM);

            return Ok(new SuccessResponseVM<FeedbackVM>()
            {
                Message = "Create new feedback successfully",
                Data = feedbackVMResult
            });
        }

        [HttpPost("add-to-block")]
        public async Task<IActionResult> AddToBlock(int fbId, int score, string userId, string comment)
        {
            await _feedbackRepo.AddFeedback(fbId, score, userId, comment);
            return Ok();
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

        [HttpGet("filter/{locationId}")]
        public async Task<IActionResult> GetFeedbacksByFilter(int locationId, [FromQuery] decimal rating = 5, [FromQuery] int timeFeedbackType = 0, [FromQuery] int tripType = 0)
        {
            var listFeedbackByFilterVM = await _feedbackRepo.GetFeedbacksByFilterAsync(locationId, rating, timeFeedbackType, tripType);

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackVM>>()
            {
                Message = "Get feedbacks by filter successfully",
                Data = listFeedbackByFilterVM
            });
        }

        [HttpGet("read-chain")]
        public async Task<IActionResult> ReadChain()
        {
            return Ok(await _feedbackRepo.ReadChain());
        }

        [HttpGet("{userId}/{cityId}/feedbacks")]
        public async Task<IActionResult> GetFeedbackByUserIdAndCityId(string userId, int cityId)
        {
            var listFeedbackVM = await _feedbackRepo.GetFeedbacksByUserIdAndCityIdAsync(userId, cityId);

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackVM>>()
            {
                Message = "Get feedbacks by user and city successfully",
                Data = listFeedbackVM
            });
        }
    }
}
