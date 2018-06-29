using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TreeBranchWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DichotomousKey> DichotomousKeys { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DichotomousKey GetDichotomousKeyOrNotFound(string keyName)
        {
            var key = this.DichotomousKeys.SingleOrDefault(
                k => string.Compare(k.Name, keyName, true) == 0);
            if (key == null)
            {
                throw new HttpException(404, "That dichotomous key was not found.");
            }
            return key;
        }
    }
}