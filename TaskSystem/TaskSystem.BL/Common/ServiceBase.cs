using System;
using System.Linq;
using System.Security.Claims;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Utils;
using TaskSystem.DL;

namespace TaskSystem.BL.Common
{
    public abstract class ServiceBase
    {
        protected AppDbContext Db;

        protected ServiceBase(AppDbContext db)
        {
            Db = db;
        }

        public ClaimsIdentity Identity => ServiceProviders.HttpContext.User.Identity.CastTo<ClaimsIdentity>();
        public int UserId => Identity.Claims.Single(x => x.Type == "Id").Value.TryParse<int>();
        public int UserEmail => Identity.Claims.Single(x => x.Type == ClaimTypes.Email).Value.TryParse<int>();
    }
}