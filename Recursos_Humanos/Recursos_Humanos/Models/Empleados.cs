using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recursos_Humanos.Models
{
	public class Empleados
	{
        [Key]
        public int Id_Empleado { get; set; }

        //[Index(IsUnique = true)]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(4)]
        public String CodigoEmpleado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public String Nombre_Empleado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50)]
        public String Apellido { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [MaxLength(10), MinLength(9)]
        public String Telefono { get; set; }

        // [ForeignKey("Departamento")]
        public int Id_Depto { get; set; }


        public int Id_Cargo { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        public decimal Salario { get; set; }

        public bool status { get; set; }

        public Departamento Departamento { get; set; }
        public Cargo Cargo { get; set; }
        public List<Licencia> Licencias { get; set; }
        public List<Permiso> Permisos { get; set; }
        // public Salida_Empleado Salida_Empleado { get; set; }
        public List<Vacacion> Vacaciones { get; set; }
    }
}