namespace marcatel_api.Models
{
    public class NotaCargoModel
    {
        public int Id {get; set;}
        public int IdProveedor {get; set;}
        public string Proveedor {get; set;}
        public decimal Monto {get; set;}
        public string Factura {get; set;}
        public int IdFactura {get; set;}
        public int IdUsuario {get; set;}
        public string NotaEntrada {get; set;}
    }

    public class RenglonNotaCargoModel
    {
        public int Id {get; set;}
        public int IdNotaCargo {get; set;}
        public string Codigo {get; set;}
        public decimal PrecioSistema {get; set;}
        public decimal PrecioFactura {get; set;}
        public decimal Diferencia {get; set;}
    }
}