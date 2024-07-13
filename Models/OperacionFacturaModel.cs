namespace marcatel_api.Models
{
    public class OperacionFacturaModel
    {
        public int Id {get; set;}
        public string IdTicket {get; set;}
        public int IdFactura {get; set;}
        public int Usuario {get; set;}
        public decimal Total {get; set;}
        public string FolioInterno {get; set;}
        public decimal Iva {get; set;}
        public decimal Ieps {get; set;}
    }
}