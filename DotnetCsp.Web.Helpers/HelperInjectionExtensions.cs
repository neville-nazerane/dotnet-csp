using DotnetCsp.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Helpers
{
    public static class HelperInjectionExtensions
    {

        public static IServiceCollection AddWebHelpers(this IServiceCollection services) 
            => services.AddScoped<ILoginManager, LoginManager>();

    }
}
