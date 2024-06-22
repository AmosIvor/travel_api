using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories.Basics;
using travel_api.Repositories;
using travel_api.ViewModels.Responses.ResultResponseViewModel;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Requests.EFRequest;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IBaseRepo<Comment, CommentVM, CommentRequest, int> _baseRepo;
        private readonly ICommentRepo _commentRepo;
        public CommentController(IBaseRepo<Comment, CommentVM, CommentRequest, int> baseRepo, ICommentRepo commentRepo)
        {
            _baseRepo = baseRepo;
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var commentsVM = await _commentRepo.GetAllCommentsAsync();

            return Ok(new SuccessResponseVM<IEnumerable<CommentVM>>()
            {
                Message = "Get all comments successfully",
                Data = commentsVM
            });
        }

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var commentVMResult = await _commentRepo.GetCommentById(commentId);

            return Ok(new SuccessResponseVM<CommentVM>()
            {
                Message = "Get comment by id successfully",
                Data = commentVMResult
            });
        }

        [HttpGet("{userId}/comments")]
        public async Task<IActionResult> GetListCommentsByUserId(string userId)
        {
            var commentsVM = await _commentRepo.GetListCommentsByUserId(userId);

            return Ok(new SuccessResponseVM<IEnumerable<CommentVM>>()
            {
                Message = "Get list comment by user successfully",
                Data = commentsVM
            });
        }

        [HttpGet("posts/{postId}/comments")]
        public async Task<IActionResult> GetListCommentsByPostId(int postId)
        {
            var commentsVM = await _commentRepo.GetListCommentsByPostId(postId);

            return Ok(new SuccessResponseVM<IEnumerable<CommentVM>>()
            {
                Message = "Get list comment by post successfully",
                Data = commentsVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentRequest commentVM)
        {
            var commentVMResult = await _baseRepo.AddAsync(commentVM);

            return Ok(new SuccessResponseVM<CommentVM>()
            {
                Message = "Create new comment successfully",
                Data = commentVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentRequest commentVM)
        {
            var commentVMResult = await _baseRepo.UpdateAsync(commentVM);

            return Ok(new SuccessResponseVM<CommentVM>()
            {
                Message = "Update comment successfully",
                Data = commentVMResult
            });
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId)
        {
            var commentVMResult = await _baseRepo.DeleteAsync(commentId);

            return Ok(new SuccessResponseVM<CommentVM>()
            {
                Message = "Delete comment successfully",
                Data = commentVMResult
            });
        }
    }
}
