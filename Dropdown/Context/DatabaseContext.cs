using Dropdown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dropdown.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FeedBack> Feedback { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
    }
}