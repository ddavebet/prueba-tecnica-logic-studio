namespace Backend.Application.DTOs.Response
{
    public class UsuarioAutenticadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Token { get; set; }
    }
}
