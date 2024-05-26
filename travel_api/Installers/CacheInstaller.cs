using StackExchange.Redis;
using travel_api.Configuration;
using travel_api.Repositories.Utils;
using travel_api.Services.Utils;

namespace travel_api.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();

            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

            services.AddSingleton(redisConfiguration);

            if (!redisConfiguration.Enabled)
                return;

            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
