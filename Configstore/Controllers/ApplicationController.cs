using System.Web.Mvc;
using Configstore.Models;

namespace Configstore.Controllers
{ 
    public class ApplicationController : Controller
    {
        private readonly IConfigRepository _repository;

        public ApplicationController(IConfigRepository repository)
        {
            _repository = repository;
        }

        public ApplicationController()
        {
            _repository = new ConfigRepository();
        }

        //
        // GET: /Application/

        public ViewResult Index()
        {
            return View(_repository.GetAllApplications());
        }

        //
        // GET: /Application/Details/5

        public ViewResult Details(int id)
        {
            Application application = _repository.FindApplicationById(id);
            return View(application);
        }

        //
        // GET: /Application/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Application/Create

        [HttpPost]
        public ActionResult Create(Application application)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(application);
                return RedirectToAction("Index");  
            }

            return View(application);
        }

        //
        // GET: /Application/Delete/5
 
        public ActionResult Delete(int id)
        {
            Application application = _repository.FindApplicationById(id);
            return View(application);
        }

        //
        // POST: /Application/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Application application = _repository.FindApplicationById(id);
            _repository.Delete(application);
            return RedirectToAction("Index");
        }
    }
}