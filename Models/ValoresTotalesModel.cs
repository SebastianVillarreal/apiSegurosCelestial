namespace marcatel_api.Models
{
    public class ValoresTotalesModel
    {
        public int id {get; set;}
        public string concepto {get; set;}
        public decimal importe {get; set;}
        public decimal iepsOcho {get; set;}
        public decimal iepsVS {get; set;}
        public decimal IepsTreinta {get; set;}
        public decimal iepsCincuenta {get; set;}

    }

    public class DesgloseConceptosModel
    {
        public decimal Efectivo {get; set;}
        public decimal Credito {get; set;}
        public decimal TarjetaElectronica {get; set;}
        public decimal Separado {get; set;}
        public decimal Anticipo {get; set;}
    }

    public class ReporteTipoTipo
    {
        public string Departamento {get; set;}
        public decimal VentaGlobal {get; set;}
        public decimal DescVentas {get; set;}
        public decimal VentaBruta {get; set;}
        public decimal DevVenta {get; set;}
        public decimal DevCredito {get; set;}
        public decimal NotasCred {get; set;}
        public decimal VentaTotal {get; set;}
        public decimal Iva {get; set;}
        public decimal Ieps {get; set;}
        public decimal VentaNeta {get; set;}


    }

}