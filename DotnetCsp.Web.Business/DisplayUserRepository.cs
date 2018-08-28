using DotnetCsp.Core;
using DotnetCsp.Web.DataAccess;
using DotnetCsp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetCsp.Web.Business
{
    class DisplayUserRepository : DisplayUserAccess, IDisplayUserRepository
    {
        private readonly AppDbContext context;

        public DisplayUserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public UserDisplay Add(string userName)
        {
            var user = context.Users.SingleOrDefault(u => u.UserName == userName);
            if (user == null) return null;
            else return Add(new UserDisplay {
                DisplayName = userName,
                UserId = user.Id
            });
        }
    }
}
