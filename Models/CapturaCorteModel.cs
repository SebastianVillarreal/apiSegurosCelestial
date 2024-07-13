namespace marcatel_api.Models
{
    public class CapturaCorteModel
    {
        public int IdCorte {get; set;}
        public decimal Efectivo {get; set;}
        public decimal Credito {get; set;}
        public decimal TarjetaElectronica {get;set;}
        public decimal Separado {get; set;}
        public decimal NotaCredito {get; set;}
        public int Usuario {get; set;}
        public int IdSession {get; set;}
        public  int IdSucursal {get; set;}

    }
}