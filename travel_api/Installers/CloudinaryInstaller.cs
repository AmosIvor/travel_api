using travel_api.Configuration;

namespace travel_api.Installers
{
    public class CloudinaryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));
        }
    }
}
