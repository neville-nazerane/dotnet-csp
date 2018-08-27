using System;
using System.Collections.Generic;
using System.Text;
using DotnetCsp.Web.Business;
using DotnetCsp.Web.Helpers;
using DotnetCsp.Web.Injections;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppInjectionExtensions
    {

        public static IServiceCollection AddAllServices(
                                            this IServiceCollection services,
                                            Action<InjectionOptions> options)
        {

            var opts = new InjectionOptions();
            options?.Invoke(opts);

            return services.AddBusiness()


                            .AddWebHelpers()

                            .AddDbConfig(new DbConfigation(opts));
        }
    }
}
