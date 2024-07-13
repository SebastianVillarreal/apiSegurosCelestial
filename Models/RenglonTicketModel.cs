namespace marcatel_api.Models
{
    public class RenglonTicketModel
    {
        public int IdSucursal { get; set; }
        public string Fecha { get; set; }
        public int Folio { get; set; }
        public int Consecutivo { get; set; }
        public string Articulo { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Unidad { get; set; }
        public float Descuento { get; set; }
        public float PrecioOriginal { get; set; }
        public float Impuestos { get; set; }
        public float Iva { get; set; }
        public float Ieps { get; set; }
        public int ConLocal { get; set; }
        public string DescripcionArticulo { get; set; }
        public int Id { get; set; }
        public float Total { get; set; }
        public float subTotal {get; set;}
        public int IdTicket { get; set; }
    }

    public class FctRenglonFolioModel: RenglonTicketModel
    {
        public decimal BaseGravable{get;set;}
        public decimal TasaIva {get; set;}
        public decimal TasaIeps {get; set;}
        public string ClaveSat {get; set;}
        
    }

    public class FctOperacionModel
    {
        public string FolioInterno {get; set;}
        public int IdSucursal {get; set;}
        public string FechaVenta {get; set;}
        public decimal Descuento {get; set;}
        public decimal Ieps {get; set;}
        public decimal Iva {get; set;}
        public decimal TasaIva {get; set;}
        public decimal TasaIeps {get; set;}
        public decimal Venta {get; set;}
        public decimal SubTotal {get; set;}
        public decimal Impuestos {get; set;}
        public string FechaIni {get; set;}
        public string FechaFin {get; set;}
    }
}

 