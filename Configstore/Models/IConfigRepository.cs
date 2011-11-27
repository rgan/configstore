using System;
using System.Collections.Generic;

namespace Configstore.Models
{
    public interface IConfigRepository 
    {
        IEnumerable<Application> GetAllApplications();
        IEnumerable<Environment> GetAllEnvironments();
        Application FindApplicationById(int id);
        void Add(Application app);
        void Delete(Application application);
    }
}
