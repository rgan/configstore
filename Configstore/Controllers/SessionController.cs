using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configstore.Controllers
{
    public class SessionController : Controller
    {
        //
        // GET: /Session/

        public ActionResult Index()
        {
            int hits = 0;
            if (Session["hits"] != null)
            {
                hits = (int) Session["hits"];
            }
            Session["hits"] = hits + 1;
            return View();
        }

    }
}
