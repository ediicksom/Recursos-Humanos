using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class PermisosController : Controller
    {
		private GestionContext db = new GestionContext();

		// GET: Permisoes
		public ActionResult Index()
		{
			var permisos = db.Permisos.Include(p => p.Empleado);
			return View(permisos.ToList());
		}

		// GET: Permisoes/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Permiso permiso = db.Permisos.Find(id);
			if (permiso == null)
			{
				return HttpNotFound();
			}
			return View(permiso);
		}

		// GET: Permisoes/Create
		public ActionResult Create()
		{
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "Nombre_Empleado");
			return View();
		}

		// POST: Permisoes/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id_Permiso,Id_Empleado,Inicio_Permiso,Fin_Permiso,Comentario")] Permiso permiso)
		{
			if (ModelState.IsValid)
			{
				db.Permisos.Add(permiso);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", permiso.Id_Empleado);
			return View(permiso);
		}

		// GET: Permisoes/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Permiso permiso = db.Permisos.Find(id);
			if (permiso == null)
			{
				return HttpNotFound();
			}
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", permiso.Id_Empleado);
			return View(permiso);
		}

		// POST: Permisoes/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id_Permiso,Id_Empleado,Inicio_Permiso,Fin_Permiso,Comentario")] Permiso permiso)
		{
			if (ModelState.IsValid)
			{
				db.Entry(permiso).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Id_Empleado = new SelectList(db.Empleados, "Id_Empleado", "CodigoEmpleado", permiso.Id_Empleado);
			return View(permiso);
		}

		// GET: Permisoes/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Permiso permiso = db.Permisos.Find(id);
			if (permiso == null)
			{
				return HttpNotFound();
			}
			return View(permiso);
		}

		// POST: Permisoes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Permiso permiso = db.Permisos.Find(id);
			db.Permisos.Remove(permiso);
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