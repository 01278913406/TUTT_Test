using TUTT_API.Services;

namespace TUTT_API
{
    public static class ConfigService
    {
        public static IServiceCollection AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILeaguesService, LeaguesService>();

            return services;

        }
    }
}
