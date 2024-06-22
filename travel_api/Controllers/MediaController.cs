using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IBaseRepo<PostMedia, PostMediaVM, PostMediaRequest, int> _postMediaRepo;
        private readonly IBaseRepo<FeedbackMedia, FeedbackMediaVM, FeedbackMediaRequest, int> _feedbackMediaRepo;
        private readonly IBaseRepo<CommentMedia, CommentMediaVM, CommentMediaRequest, int> _commentMediaRepo;
        public MediaController(IBaseRepo<PostMedia, PostMediaVM, PostMediaRequest, int> postMediaRepo, 
                                IBaseRepo<FeedbackMedia, FeedbackMediaVM, FeedbackMediaRequest, int> feedbackMediaRepo,
                                IBaseRepo<CommentMedia, CommentMediaVM, CommentMediaRequest, int> commentMediaRepo)
        {
            _postMediaRepo = postMediaRepo;
            _feedbackMediaRepo = feedbackMediaRepo;
            _commentMediaRepo = commentMediaRepo;
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
        public async Task<IActionResult> CreatePostMedia(PostMediaRequest postMediaVM)
        {
            var postMediaVMResult = await _postMediaRepo.AddAsync(postMediaVM);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Create new post media successfully",
                Data = postMediaVMResult
            });
        }

        [HttpPut("post-medias")]
        public async Task<IActionResult> UpdatePostMedia(PostMediaRequest postMediaVM)
        {
            var postMediaVMResult = await _postMediaRepo.UpdateAsync(postMediaVM);

            return Ok(new SuccessResponseVM<PostMediaVM>()
            {
                Message = "Update post media successfully",
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
        public async Task<IActionResult> CreateFeedbackMedia(FeedbackMediaRequest feedbackMediaVM)
        {
            var feedbackMediaVMResult = await _feedbackMediaRepo.AddAsync(feedbackMediaVM);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Create new feedback media successfully",
                Data = feedbackMediaVMResult
            });
        }

        [HttpPut("feedback-medias")]
        public async Task<IActionResult> UpdateFeedbackMedia(FeedbackMediaRequest feedbackMediaVM)
        {
            var feedbackMediaVMResult = await _feedbackMediaRepo.UpdateAsync(feedbackMediaVM);

            return Ok(new SuccessResponseVM<FeedbackMediaVM>()
            {
                Message = "Update feedback media successfully",
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

        [HttpGet("comment-medias")]
        public async Task<IActionResult> GetAllCommentMedia()
        {
            var commentMediasVM = await _commentMediaRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<CommentMediaVM>>()
            {
                Message = "Get all comment medias successfully",
                Data = commentMediasVM
            });
        }

        [HttpGet("comment-medias/{commentMediaId}")]
        public async Task<IActionResult> GetCommentMediaById(int commentMediaId)
        {
            var commentMediaVM = await _commentMediaRepo.GetByIdAsync(commentMediaId);

            return Ok(new SuccessResponseVM<CommentMediaVM>()
            {
                Message = "Get comment media by id successfully",
                Data = commentMediaVM
            });
        }

        [HttpPost("comment-medias")]
        public async Task<IActionResult> CreateCommentMedia(CommentMediaRequest commentMediaVM)
        {
            var commentMediaVMResult = await _commentMediaRepo.AddAsync(commentMediaVM);

            return Ok(new SuccessResponseVM<CommentMediaVM>()
            {
                Message = "Create new comment media successfully",
                Data = commentMediaVMResult
            });
        }

        [HttpPut("comment-medias")]
        public async Task<IActionResult> UpdateCommentMedia(CommentMediaRequest commentMediaVM)
        {
            var commentMediaVMResult = await _commentMediaRepo.UpdateAsync(commentMediaVM);

            return Ok(new SuccessResponseVM<CommentMediaVM>()
            {
                Message = "Update comment media successfully",
                Data = commentMediaVMResult
            });
        }

        [HttpDelete("comment-medias/{commentMediaId}")]
        public async Task<IActionResult> DeleteCommentMediaById(int commentMediaId)
        {
            var commentMediaVM = await _commentMediaRepo.DeleteAsync(commentMediaId);

            return Ok(new SuccessResponseVM<CommentMediaVM>()
            {
                Message = "Delete comment media by id successfully",
                Data = commentMediaVM
            });
        }
    }
}
