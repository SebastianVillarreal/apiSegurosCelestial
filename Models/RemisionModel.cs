namespace marcatel_api.Models
{
    public class RemisionModel 
    {
        public int Id {get; set; }
        public int IdProveedor {get; set;}
        public string Factura {get;set;}
        public decimal Importe {get; set;}
        public string Cheque {get; set;}
        public string NombreProveedor {get;set;}
    }

}