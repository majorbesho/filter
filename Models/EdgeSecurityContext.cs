using EdgeMobile.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public class EdgeSecurityContext : DbContext
    {
        static EdgeSecurityContext()
        {
            Database.SetInitializer<EdgeSecurityContext>(null);
        }

        public EdgeSecurityContext()
            : base("Name=EdgeSecurityContext")
        {
        }
        public DbSet<SecUser> SecUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SecUserMap());
        }
    }
}