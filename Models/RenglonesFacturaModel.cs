namespace marcatel_api.Models
{
    public class RenglonFacturaModel
    {
        public int Id {get; set;}
        public int IdFactura {get; set;}
        public string Articulo {get; set;}
        public string Descripcion {get; set;}
        public decimal MontoIva {get; set;}
        public decimal MontoIeps {get; set;}
        public decimal PrecioVenta {get; set;}
        public decimal Cantidad {get; set;}
        public string UnidadMedida {get; set;}
        public decimal Total {get; set;}
        public string FolioTicket {get; set;}
        public string ClaveProdServ {get; set;}
        public string ClaveUnidad {get; set;}
        public decimal Descuento {get; set;}
    }
}