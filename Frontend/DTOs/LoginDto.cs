using System.ComponentModel.DataAnnotations;

namespace Frontend.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
