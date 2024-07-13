namespace marcatel_api.Models
{
    public class EntradaModel
    {
        public string ClaveProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreSucursal { get; set; }
        public int IdSucursal { get; set; }
        public int OrdenCompra { get; set; }
        public string NumeroNota { get; set; }
        public int Entrada { get; set; }
        public float Importe { get; set; }
        public string Factura { get; set; }
        public int IdEstatus {get; set;}
        public string Estatus {get;set;}
    }
}