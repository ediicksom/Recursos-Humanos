using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class DepartamentosController : Controller
    {
		private GestionContext db = new GestionContext();

		// GET: Departamentos
		public ActionResult Index()
		{
			return View(db.Departamentos.ToList());
		}

		// GET: Departamentos/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Departamento departamento = db.Departamentos.Find(id);
			if (departamento == null)
			{
				return HttpNotFound();
			}
			return View(departamento);
		}

		// GET: Departamentos/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Departamentos/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id_Depto,Codigo_Depto,Nombre_Depto")] Departamento departamento)
		{
			if (ModelState.IsValid)
			{
				db.Departamentos.Add(departamento);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(departamento);
		}

		// GET: Departamentos/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Departamento departamento = db.Departamentos.Find(id);
			if (departamento == null)
			{
				return HttpNotFound();
			}
			return View(departamento);
		}

		// POST: Departamentos/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id_Depto,Codigo_Depto,Nombre_Depto")] Departamento departamento)
		{
			if (ModelState.IsValid)
			{
				db.Entry(departamento).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(departamento);
		}

		// GET: Departamentos/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Departamento departamento = db.Departamentos.Find(id);
			if (departamento == null)
			{
				return HttpNotFound();
			}
			return View(departamento);
		}

		// POST: Departamentos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Departamento departamento = db.Departamentos.Find(id);
			db.Departamentos.Remove(departamento);
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