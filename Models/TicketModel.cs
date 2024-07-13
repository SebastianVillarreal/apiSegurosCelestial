namespace marcatel_api.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public int IdSucursal { get; set; }
        public float Total { get; set; }
        public float Impuestos { get; set; }
        public float SubTotal { get; set; }
        public int Estatus { get; set; }
        public int IdUsuario { get; set; }
        public string FolioInterno { get; set; }
        public string FechaHora { get; set; }
        public float Descuento { get; set; }
        public int Caja { get; set; }
        public string AAAADDMM { get; set; }
        public string NombreSucursal { get; set; }
        public string Cliente { get; set; }
        public string Cajero { get; set; }
        public string rfc {get; set;}
        public int numeroCliente {get; set;}
        public string DescEstatus {get; set;}
        public decimal Iva {get; set;}
        public decimal Ieps {get; set;}
        public decimal IepsSeis {get; set;}
        public string Hora {get; set;}
    }
}

