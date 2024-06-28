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
    public class PostController : ControllerBase
    {
        private readonly IBaseRepo<Post, PostVM, PostRequest, int> _baseRepo;
        private readonly IPostRepo _postRepo;
        public PostController(IBaseRepo<Post, PostVM, PostRequest, int> baseRepo, IPostRepo postRepo)
        {
            _baseRepo = baseRepo;
            _postRepo = postRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var postsVM = await _postRepo.GetAllPostsAsync();

            return Ok(new SuccessResponseVM<IEnumerable<PostVM>>()
            {
                Message = "Get all posts successfully",
                Data = postsVM
            });
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var postVMResult = await _postRepo.GetPostByIdAsync(postId);

            return Ok(new SuccessResponseVM<PostVM>()
            {
                Message = "Get post by id successfully",
                Data = postVMResult
            });
        }

        [HttpGet("{userId}/posts-by-user")]
        public async Task<IActionResult> GetListPostsByUserId(string userId)
        {
            var postsVM = await _postRepo.GetListPostsByUserIdAsync(userId);

            return Ok(new SuccessResponseVM<IEnumerable<PostVM>>()
            {
                Message = "Get list post by user successfully",
                Data = postsVM
            });
        }

        [HttpGet("get-posts-by-content")]
        public async Task<IActionResult> GetPostsByContent(string content)
        {
            var posts = await _postRepo.GetPostByContentAsync(content);

            return Ok(new SuccessResponseVM<IEnumerable<PostVM>>()
            {
                Message = "Get posts by content successfully",
                Data = posts
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostRequest postVM)
        {
            var postVMResult = await _baseRepo.AddAsync(postVM);

            return Ok(new SuccessResponseVM<PostVM>()
            {
                Message = "Create new post successfully",
                Data = postVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostRequest postVM)
        {
            var postVMResult = await _baseRepo.UpdateAsync(postVM);

            return Ok(new SuccessResponseVM<PostVM>()
            {
                Message = "Update post successfully",
                Data = postVMResult
            });
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var postVMResult = await _baseRepo.DeleteAsync(postId);

            return Ok(new SuccessResponseVM<PostVM>()
            {
                Message = "Delete post successfully",
                Data = postVMResult
            });
        }

        [HttpGet("top-10-post")]
        public async Task<IActionResult> GetTop10PostWithHighestQuantityComment()
        {
            var postsVMResult = await _postRepo.GetTop10PostWithHighestQuantityCommentAsync();

            return Ok(new SuccessResponseVM<IEnumerable<PostVM>>()
            {
                Message = "Get top 10 post successfully",
                Data = postsVMResult
            });
        }

        [HttpGet("{cityId}/posts-by-city")]
        public async Task<IActionResult> GetPostsByCityId(int cityId)
        {
            var postsVMResult = await _postRepo.GetPostsByCityIdAsync(cityId);

            return Ok(new SuccessResponseVM<IEnumerable<PostVM>>()
            {
                Message = "Get list post by city successfully",
                Data = postsVMResult
            });
        }
    }
}
