using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Salida_Empleado
	{
        [Key]
        public int Id_Salida { get; set; }
        public int Id_Empleado { get; set; }

        [Required]
        public String Tipo_Salida { get; set; } //(Renuncia, Despido, Desahucio)

        [Required]
        public String Motivo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Salida { get; set; }

        public Empleado Empleado { get; set; }
    }
}