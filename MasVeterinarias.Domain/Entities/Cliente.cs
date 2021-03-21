using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Cita = new HashSet<Cita>();
        }

       
        public int? UsuarioId { get; set; }
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
