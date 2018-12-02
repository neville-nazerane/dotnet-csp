using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCsp.WebAPI
{
    public static class WebHostExtensions
    {

        const string urlKey = "USING_URLS";

        public static IWebHostBuilder UseUrlIfExists(this IWebHostBuilder webHost)
        {
            var urls = Environment.GetEnvironmentVariable(urlKey)?.Split(";");
            if (urls != null) webHost.UseUrls(urls);
            return webHost;
        }

    }
}
