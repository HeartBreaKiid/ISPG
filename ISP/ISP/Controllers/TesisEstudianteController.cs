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
    public class TesisEstudianteController : Controller
    {
        private ProyectoISEntities2 db = new ProyectoISEntities2();

        // GET: /TesisEstudiante/
        public ActionResult Index()
        {
            var titulaciontesis = db.TitulacionTesis.Include(t => t.Titulacion);
            return View(titulaciontesis.ToList());
        }

        // GET: /TesisEstudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitulacionTesis titulaciontesis = db.TitulacionTesis.Find(id);
            if (titulaciontesis == null)
            {
                return HttpNotFound();
            }
            return View(titulaciontesis);
        }

        // GET: /TesisEstudiante/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Titulacion, "ID", "Estatus");
            return View();
        }

        // POST: /TesisEstudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,NombreProyecto,NomEmp,NomAlumno,Carrera,AsesorInterno,AsesorExterno,Fecha,Agradecimientos,Resumen,Indice,estatus")] TitulacionTesis titulaciontesis)
        {
            if (ModelState.IsValid)
            {
                db.TitulacionTesis.Add(titulaciontesis);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            ViewBag.ID = new SelectList(db.Titulacion, "ID", "Estatus", titulaciontesis.ID);
            return View(titulaciontesis);
        }

        // GET: /TesisEstudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitulacionTesis titulaciontesis = db.TitulacionTesis.Find(id);
            if (titulaciontesis == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Titulacion, "ID", "Estatus", titulaciontesis.ID);
            return View(titulaciontesis);
        }

        // POST: /TesisEstudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,NombreProyecto,NomEmp,NomAlumno,Carrera,AsesorInterno,AsesorExterno,Fecha,Agradecimientos,Resumen,Indice,estatus")] TitulacionTesis titulaciontesis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titulaciontesis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Titulacion, "ID", "Estatus", titulaciontesis.ID);
            return View(titulaciontesis);
        }

        // GET: /TesisEstudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitulacionTesis titulaciontesis = db.TitulacionTesis.Find(id);
            if (titulaciontesis == null)
            {
                return HttpNotFound();
            }
            return View(titulaciontesis);
        }

        // POST: /TesisEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TitulacionTesis titulaciontesis = db.TitulacionTesis.Find(id);
            db.TitulacionTesis.Remove(titulaciontesis);
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
