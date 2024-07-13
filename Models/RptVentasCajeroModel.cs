namespace marcatel_api.Models
{
    public class RptVentasCajeros
    {
        public string NombreUsuario {get;set ;}
        public string Fecha {get; set;}
        public int IdCajero {get;set;}
        public string Cajero {get;set;}
        public decimal Ventas {get; set;}
        public decimal SubTotal {get;set;}
        public decimal Iva {get;set;}
        public decimal Ieps {get;set;}
        public int Operaciones {get;set;}
        public int Devoluciones {get;set;}
        public decimal MontoDevoluciones {get; set;}
        public decimal SumaImpuestos {get; set;}

    }
}