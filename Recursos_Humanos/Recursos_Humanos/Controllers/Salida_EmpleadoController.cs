using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class Salida_EmpleadoController : Controller
    {
        private GestionContext db = new GestionContext();

        // GET: Salida_Empleado
        public ActionResult Index()
        {
            var salidas_Empleados = db.Salidas_Empleados.Include(s => s.Empleado);
            return View(salidas_Empleados.ToList());
        }

        // GET: Salida_Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salidas_Empleados.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Id_Empleado = new SelectList(from x in db.Empleados
                                                 where x.status == true
                                                 select x, "Id_Empleado", "Nombre_Empleado");

            //new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado");
            return View();
        }

        // POST: Salida_Empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Salida,Id_Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida_Empleado salida_Empleado)
        {
            if (ModelState.IsValid)
            {
                //var salida = (from x in db.Empleados
                //              where x.status == true
                //              select x).FirstOrDefault();
                //salida.status = false;

                Empleado emp;
                db.Salidas_Empleados.Add(salida_Empleado);
                emp = db.Empleados.Find(salida_Empleado.Id_Empleado);
                emp.status = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado", salida_Empleado.Id_Empleado);
            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salidas_Empleados.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", salida_Empleado.Id_Empleado);
            return View(salida_Empleado);
        }

        // POST: Salida_Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Salida,Id_Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida_Empleado salida_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", salida_Empleado.Id_Empleado);
            return View(salida_Empleado);
        }

        // GET: Salida_Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleado salida_Empleado = db.Salidas_Empleados.Find(id);
            if (salida_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleado);
        }

        // POST: Salida_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida_Empleado salida_Empleado = db.Salidas_Empleados.Find(id);
            db.Salidas_Empleados.Remove(salida_Empleado);
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