using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.Services
{
    public interface ILoginManager
    {

        int UserId { get; }

        bool IsLoggedIn { get; }

    }
}
