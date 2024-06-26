using Microsoft.AspNetCore.Mvc;
using System.Net;
using travel_api.Repositories.Basics;
using travel_api.Repositories.Utils;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Requests.MediaRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;
using travel_api.ViewModels.Responses.UtilViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IPhotoService _photoService;
        public UserController(IUserRepo userRepo, IPhotoService photoService)
        {
            _userRepo = userRepo;
            _photoService = photoService;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(200, Type = typeof(ICollection<UserVM>))]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var usersVM = await _userRepo.GetUsersAsync();

                return Ok(new SuccessResponseVM<ICollection<UserVM>>()
                {
                    Message = "Get list user successfully",
                    Data = usersVM
                });
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorResponseVM()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = e.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest req)
        {
            var userVM = await _userRepo.UpdateUserAsync(req);

            return Ok(new SuccessResponseVM<UserVM>()
            {
                Message = "Update user successfully",
                Data = userVM
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var userVM = await _userRepo.GetUserByIdAsync(userId);

            return Ok(new SuccessResponseVM<UserVM>()
            {
                Message = "Get user by id successfully",
                Data = userVM
            });
        }

        [HttpPost("photo")]
        public async Task<IActionResult> CreatePhoto(FileRequest file)
        {
            try
            {
                var newPhotoVM = await _photoService.CreatePhotoAsync(file);

                return Ok(new SuccessResponseVM<PhotoVM>()
                {
                    Message = "Create new photo successfully",
                    Data = newPhotoVM
                });
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorResponseVM()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = e.Message
                });
            }
        }

        [HttpPost("photos")]
        public async Task<IActionResult> CreatePhotos(ICollection<FileRequest> files)
        {
            try
            {
                var newPhotosVM = await _photoService.CreatePhotosAsync(files);

                return Ok(new SuccessResponseVM<ICollection<PhotoVM>>()
                {
                    Message = "Create list new photo successfully",
                    Data = newPhotosVM
                });
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorResponseVM()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = e.Message
                });
            }
        }

        [HttpDelete("photo/{photoId}")]
        public async Task<IActionResult> DeletePhoto(int photoId)
        {
            try
            {
                var photoDeleteVM = await _photoService.DeletePhotoAsync(photoId);

                return Ok(new SuccessResponseVM<PhotoVM>()
                {
                    Message = "Delete photo successfully",
                    Data = photoDeleteVM
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = e.Message
                });
            }
        }

        [HttpDelete("photos")]
        public async Task<IActionResult> DeletePhoto([FromQuery] ICollection<int> photoIds)
        {
            try
            {
                var photosDeleteVM = await _photoService.DeletePhotosAsync(photoIds);

                return Ok(new SuccessResponseVM<ICollection<PhotoVM>>()
                {
                    Message = "Delete list photo successfully",
                    Data = photosDeleteVM
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseVM()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = e.Message
                });
            }
        }
    }
}
