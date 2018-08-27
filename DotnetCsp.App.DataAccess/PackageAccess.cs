using DotnetCsp.App.Connections;
using DotnetCsp.Core;
using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCsp.App.DataAccess
{
    public class PackageAccess
    {
        private readonly MainConsumer consumer;

        const string path = "api/packages";

        public PackageAccess(MainConsumer consumer)
        {
            this.consumer = consumer;
        }

        public async Task<ApiConsumedResponse<Package>> Get(string name)
            => await consumer.GetAsync<Package>($"{path}/{name}");
        

    }
}
