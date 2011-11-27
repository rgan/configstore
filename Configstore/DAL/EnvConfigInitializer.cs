using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Configstore.Models
{
    public class EnvConfigInitializer : DropCreateDatabaseAlways<ConfigContext>
    {
        protected override void Seed(ConfigContext context)
        {
            var app = new Application() { Name = "App" };
            context.Applications.Add(app);
            context.SaveChanges();

            var env = new List<Environment> { 
                new Environment { Name = "Dev" },
                new Environment { Name = "QA" },
                new Environment { Name = "UAT" },
                new Environment { Name = "Prod" }
            };
            env.ForEach(e => context.Environments.Add(e));
            context.SaveChanges();

            var appConfigs = new List<ApplicationConfig> {
                new ApplicationConfig()
                {
                    ApplicationID = app.ApplicationID,
                    EnvironmentID = env[0].EnvironmentID,
                    Key = "foo",
                    Value = "bar_dev"
                },
                new ApplicationConfig()
                {
                    ApplicationID = app.ApplicationID,
                    EnvironmentID = env[1].EnvironmentID,
                    Key = "foo",
                    Value = "bar_qa"
                }};

            appConfigs.ForEach(a => context.ApplicationConfigs.Add(a));
            context.SaveChanges();
        }

    }
}