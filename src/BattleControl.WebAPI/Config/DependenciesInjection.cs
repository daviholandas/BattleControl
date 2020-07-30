using BattleControl.WebAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleControl.WebAPI.Config
{
    public static class DependenciesInjection
    {
        public static IServiceCollection IoC(this IServiceCollection services)
        {
            services.AddSingleton<IGetClientsConnectedService, GetClientsConnectedService>();
            return services;
        }
    }
}