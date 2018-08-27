using DotnetCsp.Core;
using DotnetCsp.Models;
using DotnetCsp.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.DataAccess
{
    public class PackageAccess
    {
        private readonly AbstractDbContext context;

        public PackageAccess(AbstractDbContext context)
        {
            this.context = context;
        }

        public Package Add(PackageAdd package, int createdById)
        {
            var toAdd = new Package {
                Name = package.Name,
                CreatedById = createdById,
                CreatedOn = DateTime.Now
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public ClientPackage AddClient(ClientPackageAdd clientPackage, int createdbyId)
        {
            var toAdd = new ClientPackage {
                CreatedById = createdbyId,
                CreatedOn = DateTime.Now,
                Source = clientPackage.Source,
                OnlyFiles = clientPackage.OnlyFiles,
                PackageId = clientPackage.PackageId
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public ServerPackage AddServer(ServerPackageAdd serverPackage, int createdbyId)
        {
            var toAdd = new ServerPackage
            {
                CreatedById = createdbyId,
                CreatedOn = DateTime.Now,
                PackageName = serverPackage.PackageName,
                PackageId = serverPackage.PackageId
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

    }
}
