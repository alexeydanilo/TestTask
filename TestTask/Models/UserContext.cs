using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}