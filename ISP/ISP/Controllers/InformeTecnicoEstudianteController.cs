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
    public class InformeTecnicoEstudianteController : Controller
    {
        private ProyectoISEntities2 db = new ProyectoISEntities2();

        // GET: /InformeTecnicoEstudiante/
        public ActionResult Index()
        {
            var informetecnico = db.InformeTecnico.Include(i => i.Anteproyecto).Include(i => i.Usuario);
            return View(informetecnico.ToList());
        }

        // GET: /InformeTecnicoEstudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformeTecnico informetecnico = db.InformeTecnico.Find(id);
            if (informetecnico == null)
            {
                return HttpNotFound();
            }
            return View(informetecnico);
        }

        // GET: /InformeTecnicoEstudiante/Create
        public ActionResult Create()
        {
            ViewBag.AnteProyectoID = new SelectList(db.Anteproyecto, "ID", "NombreProyecto");
            ViewBag.AlumnoID = new SelectList(db.Usuario, "NumeroDeControl", "Nombre");
            return View();
        }

        // POST: /InformeTecnicoEstudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,AlumnoID,AnteProyectoID,NombreProyecto,NomEmp,NomAlumno,Carrera,AsesorInterno,AsesorExterno,Fecha,Agradecimientos,Resumen,Indice,estatus")] InformeTecnico informetecnico)
        {
            if (ModelState.IsValid)
            {
                db.InformeTecnico.Add(informetecnico);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            ViewBag.AnteProyectoID = new SelectList(db.Anteproyecto, "ID", "NombreProyecto", informetecnico.AnteProyectoID);
            ViewBag.AlumnoID = new SelectList(db.Usuario, "NumeroDeControl", "Nombre", informetecnico.AlumnoID);
            return View(informetecnico);
        }

        // GET: /InformeTecnicoEstudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformeTecnico informetecnico = db.InformeTecnico.Find(id);
            if (informetecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnteProyectoID = new SelectList(db.Anteproyecto, "ID", "NombreProyecto", informetecnico.AnteProyectoID);
            ViewBag.AlumnoID = new SelectList(db.Usuario, "NumeroDeControl", "Nombre", informetecnico.AlumnoID);
            return View(informetecnico);
        }

        // POST: /InformeTecnicoEstudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,AlumnoID,AnteProyectoID,NombreProyecto,NomEmp,NomAlumno,Carrera,AsesorInterno,AsesorExterno,Fecha,Agradecimientos,Resumen,Indice,estatus")] InformeTecnico informetecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informetecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnteProyectoID = new SelectList(db.Anteproyecto, "ID", "NombreProyecto", informetecnico.AnteProyectoID);
            ViewBag.AlumnoID = new SelectList(db.Usuario, "NumeroDeControl", "Nombre", informetecnico.AlumnoID);
            return View(informetecnico);
        }

        // GET: /InformeTecnicoEstudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformeTecnico informetecnico = db.InformeTecnico.Find(id);
            if (informetecnico == null)
            {
                return HttpNotFound();
            }
            return View(informetecnico);
        }

        // POST: /InformeTecnicoEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformeTecnico informetecnico = db.InformeTecnico.Find(id);
            db.InformeTecnico.Remove(informetecnico);
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
