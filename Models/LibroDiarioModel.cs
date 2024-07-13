namespace marcatel_api.Models
{
    public class LibroDiarioModel
    {
        public int id {get; set;}
        public int idProveedor {get; set;}
        public string numeroNota {get; set;}
        public string nombreProveedor {get; set;}
        public decimal subTotal {get; set;}
        public decimal total {get; set;}
        public decimal iva {get; set;}
        public decimal ieps {get; set;}
        public string fecha {get; set;}
        public decimal saldo {get;set;}
        public int IdEntrada {get; set;}
    }
}