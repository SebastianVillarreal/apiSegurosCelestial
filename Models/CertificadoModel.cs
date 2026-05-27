namespace apiSegurosCelestial.Models
{
    public class InsertCertificadoModel
    {
        public int Folio { get; set; }
        public int IdVendedor { get; set; }
        public string NombreCliente { get; set; }
        public decimal ValorPaquete { get; set; }
        public decimal PagoInicial { get; set; }
        public decimal MontoMensualidad { get; set; }
        public int Estatus { get; set; } = 1;
    }

    public class CertificadoModel : InsertCertificadoModel
    {
        public int Id { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
    }

    public class InsertCertificadoAbonoModel
    {
        public int IdCertificado { get; set; }
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuario { get; set; }
    }

    public class CertificadoAbonoInsertResponse
    {
        public string Mensaje { get; set; }
        public int IdAbono { get; set; }
        public int IdCertificado { get; set; }
        public int FolioAbono { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal MontoAbono { get; set; }
        public decimal SaldoActual { get; set; }
    }
}