using DotnetCsp.Core;
using DotnetCsp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Services
{
    public interface IPackageRepository
    {

        Package Add(PackageAdd package);

        Package Get(string name, bool includeAll = false);

        Package Get(int id, bool includeAll = false);

        IEnumerable<Package> ListForCurrentUser();

        ClientPackage AddClient(ClientPackageAdd client);

        ServerPackage AddServer(ServerPackageAdd server);

    }
}
