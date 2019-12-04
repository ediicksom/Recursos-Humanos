using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recursos_Humanos.Controllers
{
    public class NominasController : Controller
    {
        private GestionContext db = new GestionContext();

        // GET: Nominas
        public ActionResult Index()
        {

            var nominas = db.GetNominas.ToList();

            return View(nominas);
            //ViewBag.NominaSum = db.Empleados.Where(x => x.status == true).Sum(x => x.Salario);
            //return View(db.GetNominas.Where(x => x.Año == ano).ToList());
        }

        public ActionResult HomeNomina()
        {
            ViewBag.calcuNomina = db.Empleados.Where(x => x.status == true).Sum(x => x.Salario);
            return View();
        }

        public ActionResult calcuNomina()
        {
            var aux = db.Empleados.Where(x => x.status == true).Sum(x => x.Salario);
            Nomina nomina = new Nomina
            {
                Mes = DateTime.Now.Month,
                Año = DateTime.Now.Year,
                Monto_Total = aux
            };
            if (db.GetNominas.FirstOrDefault(x => x.Año == nomina.Año && x.Mes == nomina.Mes) != null)
            {
                return View();

            }
            else
            {
                db.GetNominas.Add(nomina);
                db.SaveChanges();
                //nomina.Monto_Total = aux;
                return RedirectToAction("Index");
            }

        }


        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.GetNominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Nomina,Año,Mes,Monto_Total")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.GetNominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.GetNominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Nomina,Año,Mes,Monto_Total")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.GetNominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.GetNominas.Find(id);
            db.GetNominas.Remove(nomina);
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