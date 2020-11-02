using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasVeterinarias.Domain.Entities
{
    public class Empleado : BaseEntity
    {        
        public string Email { get; set; }
       
        public string Descripcion { get; set; }
        
        public string Nombre { get; set; }
        
        public long Telefono { get; set; }

        //Referencias
        [ForeignKey("Servicio")]
        public int Servicioid { get; set; }
        public Servicio Servicio { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public int Codigo { get; set; }
    }
}
