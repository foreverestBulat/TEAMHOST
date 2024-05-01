using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebTeamHost.Redis.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });
        }
    }
}
