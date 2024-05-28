using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IBaseRepo<PostMedia, PostMediaVM, int> _postMediaRepo;
        private readonly IBaseRepo<FeedbackMedia, FeedbackMediaVM, int> _feedbackMediaRepo;
        public MediaController(IBaseRepo<PostMedia, PostMediaVM, int> postMediaRepo, 
                                IBaseRepo<FeedbackMedia, FeedbackMediaVM, int> feedbackMediaRepo)
        {
            _postMediaRepo = postMediaRepo;
            _feedbackMediaRepo = feedbackMediaRepo;
        }

        [HttpGet("post-medias")]
        public async Task<IActionResult> GetAllPostMedia()
        {
            var postMediasVM = await _postMediaRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<PostMediaVM>>()
            {
                Message = "Get all post medias successfully",
                Data = postMediasVM
            });
        }

        [HttpGet("post-medias/{postMediaId}")]
        public async Task<IActionResult> GetPostMediaById(int postMediaId)
        {
            var postMediaVM = await _postMediaRepo.GetByIdAsync(postMediaId);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Get post media by id successfully",
                Data = postMediaVM
            });
        }

        [HttpPost("post-medias")]
        public async Task<IActionResult> CreatePostMedia(PostMediaVM postMediaVM)
        {
            var postMediaVMResult = await _postMediaRepo.AddAsync(postMediaVM);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Create new post media",
                Data = postMediaVMResult
            });
        }

        [HttpPut("post-medias")]
        public async Task<IActionResult> UpdatePostMedia(PostMediaVM postMediaVM)
        {
            var postMediaVMResult = await _postMediaRepo.UpdateAsync(postMediaVM);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Update post media",
                Data = postMediaVMResult
            });
        }

        [HttpDelete("post-medias/{postMediaId}")]
        public async Task<IActionResult> DeletePostMediaById(int postMediaId)
        {
            var postMediaVM = await _postMediaRepo.DeleteAsync(postMediaId);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Delete post media by id successfully",
                Data = postMediaVM
            });
        }

        [HttpGet("feedback-medias")]
        public async Task<IActionResult> GetAllFeedbackMedia()
        {
            var feedbacksMedia = await _feedbackMediaRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<FeedbackMediaVM>>()
            {
                Message = "Get all feedback medias successfully",
                Data = feedbacksMedia
            });
        }

        [HttpGet("feedback-medias/{feedbackMedia}")]
        public async Task<IActionResult> GetFeedbackMediaById(int feedbackMedia)
        {
            var feedbackMediaVM = await _feedbackMediaRepo.GetByIdAsync(feedbackMedia);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Get feedback media by id successfully",
                Data = feedbackMediaVM
            });
        }

        [HttpPost("feedback-medias")]
        public async Task<IActionResult> CreateFeedbackMedia(FeedbackMediaVM feedbackMediaVM)
        {
            var feedbackMediaVMResult = await _feedbackMediaRepo.AddAsync(feedbackMediaVM);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Create new feedback media",
                Data = feedbackMediaVMResult
            });
        }

        [HttpPut("feedback-medias")]
        public async Task<IActionResult> UpdateFeedbackMedia(FeedbackMediaVM feedbackMediaVM)
        {
            var feedbackMediaVMResult = await _feedbackMediaRepo.UpdateAsync(feedbackMediaVM);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Update feedback media",
                Data = feedbackMediaVMResult
            });
        }

        [HttpDelete("feedback-medias/{feedbackMedia}")]
        public async Task<IActionResult> DeleteFeedbackMediaById(int feedbackMedia)
        {
            var feedbackMediaVM = await _feedbackMediaRepo.DeleteAsync(feedbackMedia);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Delete feedback media by id successfully",
                Data = feedbackMediaVM
            });
        }
    }
}
