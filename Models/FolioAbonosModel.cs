namespace marcatel_api.Models
{
    public class FoliosAbonoModel
    {
        public int Id {get; set;}
        public int IdSucursal {get; set;}
        public int Usuario {get; set;}
        public decimal Monto {get; set;}
        public int IdCliente {get; set;}
        public string Fecha {get; set;}
        public string NombreCliente {get; set;}
        public string Direccion {get; set;}
        public string Rfc {get; set;}
        public decimal Total {get; set;}
        public string Referencia {get; set;}
        public int FormaPago {get; set;}
        public decimal Iva {get; set;}
        public decimal SaldoGlobal {get; set;}
    }

    public class DetalleFolioAbonoModel
    {
        public int Id {get; set;}
        public int Idfolio {get; set;}
        public decimal Monto {get; set;}
        public string FolioInterno {get; set;}
        public decimal Restante {get;set; }
    }
}