﻿using DotnetCsp.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCsp.Web.Migrations
{
    public class MigrationDbContext : AbstractDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {
        }
    }
}
