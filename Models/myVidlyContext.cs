using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myvidly.Models
{
    public class myVidlyContext : DbContext
    {
        public DbSet<membershipType> MembershipTypes { get; set; }
        public DbSet<customer> Customers { get; set; } 
        public DbSet<genre>Genres { get; set; }
        public DbSet<movie> Movies { get; set; }
    }
}