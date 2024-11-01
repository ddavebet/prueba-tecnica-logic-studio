using System.ComponentModel.DataAnnotations;

namespace Frontend.DTOs
{
    public class TareaDto
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public bool Completada { get; set; }
    }
}
