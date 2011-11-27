using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configstore.Models
{
    public class Environment
    {
        public int EnvironmentID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ApplicationConfig> ApplicationConfig { get; set; } 
    }
}