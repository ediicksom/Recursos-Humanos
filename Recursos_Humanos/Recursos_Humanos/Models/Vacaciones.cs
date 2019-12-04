using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Vacaciones
	{
        [Key]
        public int Id_Vacacion { get; set; }
        public int Id_Empleado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Inicio_Vacaciones { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fin_Vacaciones { get; set; }


        public int Año { get; set; } // Correspondiente a: (año)

        public String Comentario { get; set; }

        public Empleado Empleado { get; set; }
        //public List<Empleado> Empleados { get; set; }
    }
}