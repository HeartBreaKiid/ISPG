using ISP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISP.Controllers
{
    public class HomeController : Controller
    {
        ProyectoISEntities db = new ProyectoISEntities();
        
        public ActionResult Index()
        {
            return View(db.Proyecto.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}