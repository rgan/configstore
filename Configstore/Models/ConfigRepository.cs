using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Configstore.Models
{
    public class ConfigRepository : IConfigRepository
    {
        public IEnumerable<Application> GetAllApplications()
        {
            using(var context = new ConfigContext())
            {
                return context.Applications.ToList(); 
            }
        }

        public IEnumerable<Environment> GetAllEnvironments()
        {
            using (var context = new ConfigContext())
            {
                return context.Environments.ToList();
            }
        }

        public Application FindApplicationById(int id)
        {
            using (var context = new ConfigContext())
            {
                return context.Applications.Include("ApplicationConfig").Include("ApplicationConfig.Environment").First(a => a.ApplicationID == id);
            }
        }

        public void Add(Application app)
        {
            using (var context = new ConfigContext())
            {
                context.Applications.Add(app);
                context.SaveChanges();
            }
        }

        public void Delete(Application application)
        {
            using (var context = new ConfigContext())
            {
                var appFromDb = context.Applications.Find(application.ApplicationID);
                context.Applications.Remove(appFromDb);
                context.SaveChanges();
            }
        }
    }
}