using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Configstore.Models
{
    public class ConfigContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }                   
        public DbSet<ApplicationConfig> ApplicationConfigs { get; set; }                   
        public DbSet<Environment> Environments { get; set; }
    }
}