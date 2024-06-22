using travel_api.Models.Auths;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IAuthRepo
    {
        public Task<UserVM> SignUpAsync(UserRegister userRegister);

        public Task<AuthResponseVM> SignInAsync(UserLogin userLogin);
    }
}
