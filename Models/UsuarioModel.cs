namespace marcatel_api.Models
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int Activo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string FechaCreacion { get; set; }
    }
}

