using BattleControl.WebAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
