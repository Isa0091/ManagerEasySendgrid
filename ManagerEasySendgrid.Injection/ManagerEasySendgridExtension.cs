using ManagerEasySendgrid.Abstract;
using ManagerEasySendgrid.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid.Injection
{
    public static class ManagerEasySendgridExtension
    {
        /// <summary>
        /// Agrega la configuracion de la injeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void AddManegerManagerEasySendgrid(this IServiceCollection services, SendGridProviderConfiguration sendGridProviderConfiguration )
        {
            services.AddScoped<IManagerEasySendgridProvider>(x => new ManagerEasySendgridProvider(sendGridProviderConfiguration));
        }
    }
}
