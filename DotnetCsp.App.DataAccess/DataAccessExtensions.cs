using DotnetCsp.App.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataAccessExtensions
    {

        public static IServiceCollection AddDataAccess(this IServiceCollection services)
            => services.AddConnections()
                        .AddSingleton<PackageAccess>();


    }
}
