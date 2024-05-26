using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using travel_api.Models.Auths;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp(UserRegister userRegister)
        {
            try
            {
                var result = await _authRepo.SignUpAsync(userRegister);

                return Ok(new SuccessResponseVM<UserVM>()
                {
                    Message = "Register Successfully",
                    Data = result
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

        [HttpPost("login")]
        public async Task<IActionResult> SignIn(UserLogin userLogin)
        {
            try
            {
                var result = await _authRepo.SignInAsync(userLogin);

                return Ok(new SuccessResponseVM<AuthResponseVM>()
                {
                    Message = "Login Successfully",
                    Data = result
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
