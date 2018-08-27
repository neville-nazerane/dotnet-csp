using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.App.Connections
{
    public class MainConsumer : ApiConsumer
    {

        public MainConsumer() : base(Urls.Main)
        {

        }

    }
}
