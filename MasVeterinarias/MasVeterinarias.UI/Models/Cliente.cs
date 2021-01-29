namespace MasVeterinarias.UI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       


    }
}
