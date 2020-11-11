using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Producto : BaseEntity
    {
        
        public int VeterinariaId { get; set; }
        public string Imagen { get; set; }
        public string Marca { get; set; }
        public string Etapa { get; set; }
        public int? Stock { get; set; }
        public double? Precio { get; set; }
        public string Especie { get; set; }
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public string Raza { get; set; }
       

        public virtual Veterinaria Veterinaria { get; set; }
    }
}
