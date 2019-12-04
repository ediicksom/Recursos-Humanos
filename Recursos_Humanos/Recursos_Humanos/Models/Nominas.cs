using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Nominas
	{

        [Key]
        public int Id_Nominas { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public decimal Monto_Total { get; set; }

        //public Empleado Empleado { get; set; }
        // public List<Empleado> Empleados { get; set; }
    }
}