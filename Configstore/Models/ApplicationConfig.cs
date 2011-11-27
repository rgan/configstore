using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configstore.Models
{
    public class ApplicationConfig
    {
        public int ApplicationConfigID { get; set; }
        public int ApplicationID { get; set; }
        public int EnvironmentID { get; set; }
        public virtual Environment Environment { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}