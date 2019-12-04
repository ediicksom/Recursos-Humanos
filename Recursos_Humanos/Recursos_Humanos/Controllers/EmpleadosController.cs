using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Recursos_Humanos.Controllers
{
    public class EmpleadosController : Controller
    {
        private GestionContext db = new GestionContext();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargo).Include(e => e.Departamento);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cargo = new SelectList(db.Cargos, "Id_Cargo", "Nombre_Cargo");
            ViewBag.Id_Depto = new SelectList(db.Departamentos, "Id_Depto", "Nombre_Depto");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empleado,CodigoEmpleado,Nombre_Empleado,Apellido,Telefono,Id_Depto,Id_Cargo,FechaIngreso,Salario,status")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cargo = new SelectList(db.Cargos, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            ViewBag.Id_Depto = new SelectList(db.Departamentos, "Id_Depto", "Nombre_Depto", empleado.Id_Depto);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cargo = new SelectList(db.Cargos, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            ViewBag.Id_Depto = new SelectList(db.Departamentos, "Id_Depto", "Codigo_Depto", empleado.Id_Depto);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empleado,CodigoEmpleado,Nombre_Empleado,Apellido,Telefono,Id_Depto,Id_Cargo,FechaIngreso,Salario,status")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cargo = new SelectList(db.Cargos, "Id_Cargo", "Nombre_Cargo", empleado.Id_Cargo);
            ViewBag.Id_Depto = new SelectList(db.Departamentos, "Id_Depto", "Codigo_Depto", empleado.Id_Depto);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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


        // INFORMES

        public ActionResult EmpActivos()
        {
            var empleados = db.Empleados.Where(x => x.status == true).Include(e => e.Cargo).Include(e => e.Departamento);
            return View(empleados);
        }

        public ActionResult EmpInactivos()
        {
            var empleados = db.Empleados.Where(x => x.status == false).Include(e => e.Cargo).Include(e => e.Departamento);
            return View(empleados);
        }

        public ActionResult Informe_EntradaMes()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Informe_EntradaMesLista(int ano, int mes)
        {
            var empleados = db.Empleados.Where(x => x.FechaIngreso.Year == ano && x.FechaIngreso.Month == mes).Include(e => e.Cargo).Include(e => e.Departamento).ToList();

            if (empleados != null)
            {
                return View(empleados);
            }
            else
            {

                return RedirectToAction("Error");
            }
        }
        //[HttpPost]
        //public ActionResult Informe_EntradaMesLista(int? ano, int? mes) //recibe a;o y mes para buscar
        //{
        //    ano = int.Parse(Request.Form["ano"]);
        //    mes = int.Parse(Request.Form["mes"]);

        //    var empleados = db.Empleados.Where(x => x.FechaIngreso.Year == ano && x.FechaIngreso.Month == mes).Include(e => e.Cargo).Include(e => e.Departamento);

        //    if (empleados != null)
        //    {
        //        return View(empleados);
        //    }else{

        //        return RedirectToAction("Error");
        //    }
        //}

    }
}
