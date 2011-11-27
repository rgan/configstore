using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Configstore.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }

        [Required(ErrorMessage = "Name  is  required.")] 
        public string Name { get; set; }

        public virtual ICollection<ApplicationConfig> ApplicationConfig { get; set; }

        public IEnumerable<string> Keys()
        {
            return ApplicationConfig.Select(e => e.Key).Distinct();
        }

        public IEnumerable<Environment> Environments()
        {
            return ApplicationConfig.Select(e => e.Environment);
        }

        public string ValueForKeyIn(string key, Environment environment)
        {
            return ApplicationConfig.Where(e => e.Environment == environment && e.Key == key).First().Value;
        }
    }
}