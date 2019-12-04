using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Licencias
	{
		[Key]
		public int Id_licencia { get; set; }


		public int Id_Empleado { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Inicio_Permiso { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Fin_Permiso { get; set; }

		[Required]
		public String Motivo { get; set; }
		public String Comentario { get; set; }

		public Empleado Empleado { get; set; }
	}
}