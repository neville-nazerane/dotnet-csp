using DotnetCsp.Core;
using DotnetCsp.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.Web.DataAccess
{
    public abstract class DisplayUserAccess
    {
        private readonly AbstractDbContext context;

        public DisplayUserAccess(AbstractDbContext context)
        {
            this.context = context;
        }

        public UserDisplay Add(UserDisplay user)
        {
            var toAdd = new UserDisplay
            {
                DisplayName = user.DisplayName,
                UserId = user.UserId
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

    }
}
