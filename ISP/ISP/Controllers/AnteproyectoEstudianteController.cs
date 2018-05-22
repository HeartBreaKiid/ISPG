using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISP.Models;

namespace ISP.Controllers
{
    public class AnteproyectoEstudianteController : Controller
    {
        private ProyectoISEntities2 db = new ProyectoISEntities2();

        // GET: /AnteproyectoEstudiante/
        public ActionResult Index()
        {
            return View(db.Anteproyecto.ToList());
        }

        // GET: /AnteproyectoEstudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteproyecto anteproyecto = db.Anteproyecto.Find(id);
            if (anteproyecto == null)
            {
                return HttpNotFound();
            }
            return View(anteproyecto);
        }

        // GET: /AnteproyectoEstudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AnteproyectoEstudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,NombreProyecto,Objetivo,Justificacion,Cronograma,DescActividades,Direccion,NombreEmp,GiroEmp,DireccionEmp,CargoEmp,TelefonoEmp,CorreoElecEmp,estatus")] Anteproyecto anteproyecto)
        {
            if (ModelState.IsValid)
            {
                db.Anteproyecto.Add(anteproyecto);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            return View(anteproyecto);
        }

        // GET: /AnteproyectoEstudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteproyecto anteproyecto = db.Anteproyecto.Find(id);
            if (anteproyecto == null)
            {
                return HttpNotFound();
            }
            return View(anteproyecto);
        }

        // POST: /AnteproyectoEstudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,NombreProyecto,Objetivo,Justificacion,Cronograma,DescActividades,Direccion,NombreEmp,GiroEmp,DireccionEmp,CargoEmp,TelefonoEmp,CorreoElecEmp,estatus")] Anteproyecto anteproyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anteproyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anteproyecto);
        }

        // GET: /AnteproyectoEstudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteproyecto anteproyecto = db.Anteproyecto.Find(id);
            if (anteproyecto == null)
            {
                return HttpNotFound();
            }
            return View(anteproyecto);
        }

        // POST: /AnteproyectoEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anteproyecto anteproyecto = db.Anteproyecto.Find(id);
            db.Anteproyecto.Remove(anteproyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
