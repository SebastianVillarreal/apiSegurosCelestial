namespace marcatel_api.Models
{
    public class MovimientoModel
    {
        public int Id { get; set; }
        public string ClaveProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public int Folio { get; set; }
        public int UsuarioEntrega { get; set; }
        public int UsuarioRecibe { get; set; }
        public string Estatus { get; set; }
        public string Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string Referencia { get; set; }
        public string Nota {get; set;}
        public string Envia { get; set; }
        public int IdOrigen { get; set; }
        public string Movimiento { get; set; }
        public string NombreEstatus { get; set; }
        public int TipoAfecta { get; set; }

    }
}