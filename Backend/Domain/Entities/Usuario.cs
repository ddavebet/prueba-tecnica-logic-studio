namespace Backend.Domain.Entities
{
    public class Usuario
    {
        public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Salt { get; set; }
    }
}
