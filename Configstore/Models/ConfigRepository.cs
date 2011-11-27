using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Configstore.Models
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ConfigContext _db = new ConfigContext();

        public IEnumerable<Application> GetAllApplications()
        {
            return _db.Applications.ToList();
        }

        public IEnumerable<Environment> GetAllEnvironments()
        {
            return _db.Environments.ToList();
        }

        public Application FindApplicationById(int id)
        {
            return _db.Applications.Find(id);
        }

        public void Add(Application app)
        {
            _db.Applications.Add(app);
            _db.SaveChanges();
        }

        public void Update(Application app)
        {
            _db.Entry(app).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Application application)
        {
            _db.Applications.Remove(application);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}