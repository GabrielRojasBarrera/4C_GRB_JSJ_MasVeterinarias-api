using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.DTOs
{
    public  class ServicioRequestDto
    {
        public string Descripcion { get; set; }

        public string NombreServicio { get; set; }

        public string Especie { get; set; }

        public string Raza { get; set; }

        public string Etapa { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public string Duracion { get; set; }

        public string Estado { get; set; }
    }
}
