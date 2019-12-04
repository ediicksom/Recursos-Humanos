using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class LicenciasController : Controller
    {
		private GestionContext db = new GestionContext();

		// GET: Licencias
		public ActionResult Index()
		{
			var licencias = db.Licencias.Include(l => l.Empleado);
			return View(licencias.ToList());
		}

		// GET: Licencias/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Licencia licencia = db.Licencias.Find(id);
			if (licencia == null)
			{
				return HttpNotFound();
			}
			return View(licencia);
		}

		// GET: Licencias/Create
		public ActionResult Create()
		{
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado");
			return View();
		}

		// POST: Licencias/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id_licencia,Id_Empleado,Inicio_Permiso,Fin_Permiso,Motivo,Comentario")] Licencia licencia)
		{
			if (ModelState.IsValid)
			{
				db.Licencias.Add(licencia);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", licencia.Id_Empleado);
			return View(licencia);
		}

		// GET: Licencias/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Licencia licencia = db.Licencias.Find(id);
			if (licencia == null)
			{
				return HttpNotFound();
			}
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", licencia.Id_Empleado);
			return View(licencia);
		}

		// POST: Licencias/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id_licencia,Id_Empleado,Inicio_Permiso,Fin_Permiso,Motivo,Comentario")] Licencia licencia)
		{
			if (ModelState.IsValid)
			{
				db.Entry(licencia).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", licencia.Id_Empleado);
			return View(licencia);
		}

		// GET: Licencias/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Licencia licencia = db.Licencias.Find(id);
			if (licencia == null)
			{
				return HttpNotFound();
			}
			return View(licencia);
		}

		// POST: Licencias/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Licencia licencia = db.Licencias.Find(id);
			db.Licencias.Remove(licencia);
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