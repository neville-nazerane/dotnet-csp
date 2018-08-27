using DotnetCsp.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Business
{
    public static class BusinessInjectionExtension
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services)
            => services.AddScoped<IPackageRepository, PackageRepository>();


        public delegate void ConfigureDb<TContext>() 
            where TContext : DbContext;

        public static IServiceCollection AddDbConfig(this IServiceCollection services,
                                                        DbConfig config)
        {
            config.Configure<AppDbContext>(services);
            return services;
        }

    }

    public abstract class DbConfig
    {
        public abstract void Configure<TContext>(IServiceCollection services)
            where TContext : DbContext;
    }

}
