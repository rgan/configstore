using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Configstore.Controllers;

namespace Configstore.Tests.Controllers
{
    [TestFixture]
    public class SessionControllerTest
    {
        [Test]
        public void ShouldSetHitsOnSession()
        {
            var builder = new TestControllerBuilder();
            var controller = new SessionController();
            builder.InitializeController(controller);

            controller.Index();
            Assert.IsNotNull(controller.Session["hits"]);
        }
    }
}
