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
            services.AddScoped<IChatRepo, ChatRepo>();
            services.AddScoped<ITravelPlanRepo, TravelPlanRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IPlanDetailRepo, PlanDetailRepo>();

            // repo-utils
            services.AddScoped<IPhotoService, PhotoService>();

            // singleton
            services.AddSingleton<Web3Service>();

            // custome base
            services.AddScoped(typeof(IBaseRepo<,,,>), typeof(BaseRepo<,,,>));
        }
    }
}
