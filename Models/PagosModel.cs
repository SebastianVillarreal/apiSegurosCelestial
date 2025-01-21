namespace apiSegurosCelestial.Models
{
    public class InsertPagoModel
    {
        public int IdPoliza { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string Referencia { get; set; }
        public int IdUsuario { get; set; }
    }

    public class GetAbonosModel 
    {
        public int IdAbono {get; set;}
        public int IdPoliza {get; set;}
        public decimal Monto { get; set; }
        public string Fecha { get; set; }
        public string MetodoPago {get; set;}
        public string Referencia { get; set; }
    }

    public class GetAbonoById
    {
        public int IdAbono {get;set;}
        public int IdPoliza {get; set;}
        public string FechaAbono {get; set;}
        public string MetodoPago {get; set;}
        public string Referencia {get; set;}
        public string NombreCliente {get; set;}
        public string DomicilioCliente {get; set;}
        public int ConsecutivoPoliza {get; set;}
        public decimal MontoRestante {get; set;}
        public decimal MontoPoliza {get; set;}
        public decimal MontoAbono {get; set;}
    }

}