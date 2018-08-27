using DotnetCsp.Core;
using DotnetCsp.Models;
using DotnetCsp.Web.DataAccess;
using DotnetCsp.Web.Services;
using Microsoft.EntityFrameworkCore;
using NetCore.ModelValidation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetCsp.Web.Business
{
    class PackageRepository : PackageAccess, IPackageRepository
    {
        private readonly AppDbContext context;
        private readonly ILoginManager loginManager;
        private readonly ModelValidator modelValidator;

        int UserId => loginManager.UserId;

        public PackageRepository(AppDbContext context, 
                                ILoginManager loginManager,
                                ModelValidator modelValidator) 
            : base(context) 
        {
            this.context = context;
            this.loginManager = loginManager;
            this.modelValidator = modelValidator;
        }

        public Package Add(PackageAdd package)
        {
            if (context.Packages.Any(p => p.Name == package.Name))
            {
                var validator = modelValidator.GetHelper<PackageAdd>();
                validator.AddError(p => p.Name, PackageAdd.DuplicateName);
                return null;
            }
            return Add(package, loginManager.UserId);
        }

        public ClientPackage AddClient(ClientPackageAdd client)
        {
            var validator = modelValidator.GetHelper<ClientPackageAdd>();
            if (!context.Packages.Any(p => p.Id == client.PackageId && p.CreatedById == UserId))
            {
                modelValidator.AddError(ClientPackageAdd.InvalidPackage);
                return null;
            }
            else if (context.ClientPackages.Any(c => c.PackageId == client.PackageId
                                                                    && c.Source == client.Source))
            {
                validator.AddError(c => c.Source, ClientPackageAdd.DuplicateSource);
                return null;
            }
            else return AddClient(client, UserId);
        }

        public ServerPackage AddServer(ServerPackageAdd server)
        {
            modelValidator.GetErrors("");
            var validator = modelValidator.GetHelper<ServerPackageAdd>();
            if (!context.Packages.Any(p => p.Id == server.PackageId && p.CreatedById == UserId))
            {
                modelValidator.AddError(ServerPackageAdd.InvalidPackage);
                return null;
            }
            else if (context.ServerPackages.Any(c => c.PackageId == server.PackageId
                                                        && c.PackageName == server.PackageName))
            {
                validator.AddError(c => c.PackageName, ServerPackageAdd.DuplicateSource);
                return null;
            }
            else return AddServer(server, UserId);
        }

        IQueryable<Package> ForGet(bool includeAll = false)
        {
            IQueryable<Package> res = context.Packages.AsNoTracking();
            if (includeAll) res = res.Include(r => r.ClientPackages)
                                    .Include(r => r.ServerPackages);
            return res;
        }

        public Package Get(string name, bool includeAll = false) 
            => ForGet(includeAll).SingleOrDefault(p => p.Name == name);

        public Package Get(int id, bool includeAll = false)
            => ForGet(includeAll).SingleOrDefault(p => p.Id == id);

        public IEnumerable<Package> ListForCurrentUser()
            => context.Packages.AsNoTracking().Where(p => p.CreatedById == UserId).AsEnumerable();

    }
}
