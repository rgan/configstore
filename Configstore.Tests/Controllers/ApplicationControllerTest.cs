using System.Web.Mvc;
using Configstore.Controllers;
using Configstore.Models;
using Moq;
using NUnit.Framework;

namespace Configstore.Tests.Controllers
{
    [TestFixture]
    public class ApplicationControllerTest
    {
        private ApplicationController controller;
        private Mock<IConfigRepository> mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IConfigRepository>();
            controller = new ApplicationController(mock.Object);
        }

        [Test]
        public void CreateShouldInvokeAddApplicationOnRepository()
        {
            var application = new Application { Name = "test" };
            controller.Create(application);
            mock.Verify(m => m.Add(application));
        }

        [Test]
        public void DetailsShouldRetrieveApplication()
        {
            int appId = 1;
            var application = new Application();
            mock.Setup(m => m.FindApplicationById(appId)).Returns(application);

            ViewResult viewResult = controller.Details(appId);
            Assert.AreEqual(application, viewResult.ViewData.Model);
        }

        [Test]
        public void CreateShouldNotInvokeAddApplicationOnRepositoryIfNameIsEmpty()
        {
            var application = new Application();
            controller.ModelState.AddModelError("", "name is required");
            controller.Create(application);
            mock.Verify(m => m.Add(application), Times.Never());
        }

        [Test]
        public void DeleteConfirmedShouldInvokeDeleteOnRepository()
        {
            int appId = 1;
            var application = new Application();
            mock.Setup(m => m.FindApplicationById(appId)).Returns(application);

            controller.DeleteConfirmed(appId);

            mock.Verify(m => m.Delete(application));
        }

        [Test]
        public void DeleteConfirmedShouldRedirectToIndex()
        {
            int appId = 1;
            var application = new Application();
            mock.Setup(m => m.FindApplicationById(appId)).Returns(application);

            ActionResult result = controller.DeleteConfirmed(appId);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.AreEqual("Index", ((RedirectToRouteResult)result).RouteValues["action"]);
        }
    }
}
