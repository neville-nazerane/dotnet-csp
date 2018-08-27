using DotnetCsp.App.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessExtensions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services)
            => services.AddDataAccess()
                        .AddSingleton<PackageControl>();

    }
}
