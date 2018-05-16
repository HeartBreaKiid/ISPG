using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISP.Models;
using System.Net;

namespace ISP.Controllers
{
    public class ProyectoController : Controller
    {

        ProyectoISEntities db = new ProyectoISEntities();
        //
        // GET: /Proyecto/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,Nombre,Ambito,Descripcion,Estatus")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {  
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            return View(proyecto);
        }

        public ActionResult Ver(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }
	}
}