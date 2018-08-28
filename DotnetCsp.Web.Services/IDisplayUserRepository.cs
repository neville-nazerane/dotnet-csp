using System;
using System.Collections.Generic;
using System.Text;
using DotnetCsp.Core;

namespace DotnetCsp.Web.Services
{
    public interface IDisplayUserRepository
    {

        UserDisplay Add(UserDisplay user);
        UserDisplay Add(string userName);

    }
}
