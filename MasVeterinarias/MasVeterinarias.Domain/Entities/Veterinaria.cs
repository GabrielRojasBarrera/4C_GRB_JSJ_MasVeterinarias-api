using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.Entities
{
    public class Veterinaria : BaseEntity
    {
        
       
        public string Nombre_veterinaria { get; set; }
        
        public long Telefono { get; set; }
        
        public string Direccion { get; set; }
        
        public string Representante { get; set; }
        
        public DateTime HorarioApertura { get; set; }
       
        public DateTime HorarioCierre { get; set; }
        
        public string Diaslaborales { get; set; }
        //Referencias

        public List<Cita> Cita { get; set; }
    }
}
