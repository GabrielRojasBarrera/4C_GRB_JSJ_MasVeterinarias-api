using Microsoft.AspNetCore.Http;

namespace MasVeterinarias.UI.Models
{
    public class Veterinaria
    {
        public int Id { get; set; }
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
        public IFormFile MyFile { get; set; }

    }
}
