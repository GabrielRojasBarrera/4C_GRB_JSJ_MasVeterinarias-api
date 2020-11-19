namespace MasVeterinarias.UI.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int VeterinariaId { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public int ServicioId { get; set; }
    }
}
