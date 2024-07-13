namespace marcatel_api.Models
{
    public class CorteDiarioModel
    {
        public int id {get; set;}
        public int cajero {get; set;}
        public string nombreCajero {get; set;}
        public int caja {get; set;}
        public decimal total {get; set;}
        public decimal subTotal {get; set;}
        public decimal impuestos {get; set;}
        public decimal iva {get; set;}
        public decimal ieps {get; set;}
        public decimal notasCredito {get; set;}
        public decimal dispEfectivo {get; set;}
        public decimal devCredito {get; set;}
    }
    
}