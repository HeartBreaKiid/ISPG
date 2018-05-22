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
    public class BancoProyectoController : Controller
    {
        private ProyectoISEntities2 db = new ProyectoISEntities2();

        // GET: /BancoProyecto/
        public ActionResult Index()
        {
            return View(db.BancoProyecto.ToList());
        }

        // GET: /BancoProyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BancoProyecto bancoproyecto = db.BancoProyecto.Find(id);
            if (bancoproyecto == null)
            {
                return HttpNotFound();
            }
            return View(bancoproyecto);
        }

        // GET: /BancoProyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BancoProyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Empresa,NomProyecto,CarrNoReside,Contacto,Correo,Telefono,Ciudad")] BancoProyecto bancoproyecto)
        {
            if (ModelState.IsValid)
            {
                db.BancoProyecto.Add(bancoproyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bancoproyecto);
        }

        // GET: /BancoProyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BancoProyecto bancoproyecto = db.BancoProyecto.Find(id);
            if (bancoproyecto == null)
            {
                return HttpNotFound();
            }
            return View(bancoproyecto);
        }

        // POST: /BancoProyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Empresa,NomProyecto,CarrNoReside,Contacto,Correo,Telefono,Ciudad")] BancoProyecto bancoproyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bancoproyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bancoproyecto);
        }

        // GET: /BancoProyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BancoProyecto bancoproyecto = db.BancoProyecto.Find(id);
            if (bancoproyecto == null)
            {
                return HttpNotFound();
            }
            return View(bancoproyecto);
        }

        // POST: /BancoProyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BancoProyecto bancoproyecto = db.BancoProyecto.Find(id);
            db.BancoProyecto.Remove(bancoproyecto);
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
