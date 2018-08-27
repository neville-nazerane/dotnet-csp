using DotnetCsp.Web.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;

namespace DotnetCsp.Web.Helpers
{
    class LoginManager : ILoginManager
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public int UserId => int.Parse(
                        User.Claims.SingleOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public bool IsLoggedIn => User.Identity.IsAuthenticated;

        public LoginManager(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        ClaimsPrincipal User => httpContextAccessor.HttpContext.User;

    }
}
