using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Cargos
    {
        [Key]
        public int Id_Cargo { get; set; }



        [Required]
        [StringLength(80)]
        public String Nombre_Cargo { get; set; }

        // public Empleado Empleado { get; set; }
        // public Empleado Empleado { get; set; }
    }
}

