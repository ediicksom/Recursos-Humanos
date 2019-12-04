using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class VacacionesController : Controller
    {
        private GestionContext db = new GestionContext();

        // GET: Vacaciones
        public ActionResult Index()
        {
            var vacacions = db.Vacacions.Include(v => v.Empleado);
            return View(vacacions);
        }

        // GET: Vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacion vacacion = db.Vacacions.Find(id);
            if (vacacion == null)
            {
                return HttpNotFound();
            }
            return View(vacacion);
        }

        // GET: Vacaciones/Create
        public ActionResult Create()
        {
            //ViewBag.Id_Empleado = new SelectList(from x in db.Empleados
            //                                     where x.status == true
            //                                     select x, "Id_Empleado", "Nombre_Empleado");

            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado");
            return View();
        }

        // POST: Vacaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Vacacion,Id_Empleado,Inicio_Vacaciones,Fin_Vacaciones,Año,Comentario")] Vacacion vacacion)
        {
            if (ModelState.IsValid)
            {
                db.Vacacions.Add(vacacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado", vacacion.Id_Empleado);
            return View(vacacion);
        }

        // GET: Vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacion vacacion = db.Vacacions.Find(id);
            if (vacacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado", vacacion.Id_Empleado);
            return View(vacacion);
        }

        // POST: Vacaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Vacacion,Id_Empleado,Inicio_Vacaciones,Fin_Vacaciones,Año,Comentario")] Vacacion vacacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado", vacacion.Id_Empleado);
            return View(vacacion);
        }

        // GET: Vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacion vacacion = db.Vacacions.Find(id);
            if (vacacion == null)
            {
                return HttpNotFound();
            }
            return View(vacacion);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacacion vacacion = db.Vacacions.Find(id);
            db.Vacacions.Remove(vacacion);
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