using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using travel_api.Repositories;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;
using travel_api.ViewModels.UtilViewModel;

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
        public async Task<ActionResult> GetUsers()
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

        [HttpPost("photo")]
        public async Task<IActionResult> CreatePhoto(IFormFile file)
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
        public async Task<IActionResult> CreatePhotos(ICollection<IFormFile> files)
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
