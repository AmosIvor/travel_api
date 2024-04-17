using travel_api.Models.Auths;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Repositories
{
    public interface IAuthRepo
    {
        public Task<UserVM> SignUpAsync(UserRegister userRegister);

        public Task<AuthResponseVM> SignInAsync(UserLogin userLogin);
    }
}
