using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Veterinaria : BaseEntity
    {
        public Veterinaria()
        {
            Cita = new HashSet<Cita>();
            Empleado = new HashSet<Empleado>();
            Producto = new HashSet<Producto>();
            Servicio = new HashSet<Servicio>();
        }

        
        public int? UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Representante { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public string DiasLaborales { get; set; }
       
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
