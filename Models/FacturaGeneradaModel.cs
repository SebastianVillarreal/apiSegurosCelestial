namespace marcatel_api.Models
{
    public class FacturaGeneradaModel
    {
        public int Id {get; set;}
        public string UUID {get; set;}
        public int IdCliente {get; set;}
        public string Fecha {get; set;}
        public decimal Monto {get; set;}
        public decimal Iva {get; set;}
        public decimal Ieps {get; set;}
        public int Sucursal {get; set;}
        public int Usuario {get; set;}
        public string FormaPago{get; set;}
        public string MetodoPago {get; set;}
        public string CondicionPago {get; set;}
        public string NoCertificado {get;set;}
        public decimal Descuento {get; set;}
        public string Moneda {get; set;}
        public int TipoComprobante {get; set;}
        public string LugarExpedicion {get; set;}
        public string RfcEmisor {get; set;}
        public string RfcReceptor {get; set;}
        public string NombreEmisor {get; set;}
        public string NombreReceptor {get; set;}
        public string RegimenFiscalEmisor {get; set;}
        public string RegimenFiscalReceptor {get; set;}
        public string DomicilioFiscalReceptor {get; set;}
        public string UsoCfdi {get; set;}
        public decimal TotalImpuestosTrasladados {get; set;}
        public string Certificado {get; set;}
        public string TipoCambio {get; set;}
        public string Serie {get; set;}
        public string FolioInterno {get; set;}

        

    }
}