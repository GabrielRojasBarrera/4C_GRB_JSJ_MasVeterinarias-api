namespace MasVeterinarias.UI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool status { get; set; } = true;


    }
}
