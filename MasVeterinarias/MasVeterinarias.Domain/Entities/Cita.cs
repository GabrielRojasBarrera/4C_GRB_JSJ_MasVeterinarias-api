using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Cita : BaseEntity
    {
        public Cita()
        {
            DetallesCita = new HashSet<DetallesCita>();
        }

        
        public int VeterinariaId { get; set; }
        public int ClienteId { get; set; }
        
        public string NombreMascota { get; set; }
        public TimeSpan? Hora { get; set; }
        public DateTime? Fecha { get; set; }               
        public int ServicioId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual Veterinaria Veterinaria { get; set; }
        public virtual ICollection<DetallesCita> DetallesCita { get; set; }
    }
}
