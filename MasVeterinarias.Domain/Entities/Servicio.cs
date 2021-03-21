using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Servicio : BaseEntity
    {
        public Servicio()
        {
            Cita = new HashSet<Cita>();
            Empleado = new HashSet<Empleado>();
        }

       
        public int CategoriaId { get; set; }
        public int VeterinariaId { get; set; }
        public string Disponibilidad { get; set; }
        public string Imagen { get; set; }
        public string Detalles { get; set; }
        public double? Precio { get; set; }
        public string Especie { get; set; }
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        public string Raza { get; set; }
        

        public virtual Categoria Categoria { get; set; }
        public virtual Veterinaria Veterinaria { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
