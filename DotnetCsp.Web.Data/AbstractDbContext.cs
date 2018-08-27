using System;
using System.Collections.Generic;
using System.Text;
using DotnetCsp.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetCsp.Web.Data
{
    public class AbstractDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public DbSet<Package> Packages { get; set; }

        public DbSet<ClientPackage> ClientPackages { get; set; }

        public DbSet<ServerPackage> ServerPackages { get; set; }

        public DbSet<User> AppUsers { get; set; }

        public AbstractDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
