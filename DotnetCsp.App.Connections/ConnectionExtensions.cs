using DotnetCsp.App.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConnectionExtensions
    {

        public static IServiceCollection AddConnections(this IServiceCollection services)
            => services.AddSingleton<MainConsumer>();

    }
}
