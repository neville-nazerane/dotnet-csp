using DotnetCsp.Core;
using DotnetCsp.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Injections
{
    class DbConfigation : Business.DbConfig
    {
        private readonly IConfiguration configuration;

        public DbConfigation(InjectionOptions options)
        {
            configuration = options.Configuration;
        }

        public override void Configure<TContext>(IServiceCollection services)
        {

            services.AddDbContext<TContext>(config
                        => config.UseSqlServer(configuration.GetConnectionString(DB.SqlServerConnection)));

            services.AddIdentity<User, IdentityRole<int>>()
                    .AddEntityFrameworkStores<TContext>();
            

        }
    }
}
