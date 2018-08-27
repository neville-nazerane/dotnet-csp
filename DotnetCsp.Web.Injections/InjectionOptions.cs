using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Injections
{
    public class InjectionOptions
    {

        public IConfiguration Configuration { get; set; }

        internal InjectionOptions()
        {

        }

    }
}
