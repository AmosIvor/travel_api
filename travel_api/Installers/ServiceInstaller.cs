using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.Repositories.Utils;
using travel_api.Services;
using travel_api.Services.Basics;
using travel_api.Services.Utils;

namespace travel_api.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // ADD SCOPED REPOSITORIES

            // repo-auths
            services.AddScoped<IAuthRepo, AuthRepo>();

            // repo-ef
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IFeedbackRepo, FeedbackRepo>();
            services.AddScoped<ICommentRepo, CommentRepo>();
            services.AddScoped<ILocationRepo, LocationRepo>();

            // repo-utils
            services.AddScoped<IPhotoService, PhotoService>();

            // custome base
            services.AddScoped(typeof(IBaseRepo<,,,>), typeof(BaseRepo<,,,>));
        }
    }
}
