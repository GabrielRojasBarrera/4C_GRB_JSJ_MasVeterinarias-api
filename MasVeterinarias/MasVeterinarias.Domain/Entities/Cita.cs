using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasVeterinarias.Domain.Entities
{
    public class Cita :  BaseEntity
    {
                        
        public string Especie { get; set; }
        
        public string Raza { get; set; }
        
        public string Servicio { get; set; }
        
        public string Categoria { get; set; }
        
        public DateTime Fecha_cita { get; set; }
        
        public DateTime Hora_cita { get; set; }
        
        public string Estado { get; set; }


        //Referencias
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("veterinaria")]
        public int VeterinariaId { get; set; }
        public Veterinaria Veterinaria { get; set; }
        public ICollection<Detalles> Detalles { get; set; }
    }
}
