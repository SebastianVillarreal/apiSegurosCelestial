namespace marcatel_api.Models
{
    public class RenglonMovimientoModel
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public int IdSucursal { get; set;  }
        public string Tipo { get; set;  }
        public string Articulo { get; set; }
        public float Precio { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int SucursalDestino { get; set; }
        public int Estatus { get; set; }
        public float CantidadEnviada { get; set; }
        public float CantidadSurtida { get; set; }
        public string Fecha { get; set; }
        public float Faltante { get; set; }
        public float Existencia { get; set; }
        public int IdMovimiento { get; set; }
        public float Total { get; set; }
        public int Devuelto { get; set; }
        public float UltimoCosto { get; set; }
    }
}