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
        public int TipoCertificado { get; set; }
    }

    public class CertificadoModel : InsertCertificadoModel
    {
        public int Id { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
        public string DescripcionTipo { get; set; }
        public decimal TotalAbonado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string VendedorNombre { get; set; }
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

    public class CertificadoAbonoModel
    {
        public int Id { get; set; }
        public int IdCertificado { get; set; }
        public int FolioAbono { get; set; }
        public string FechaAbono { get; set; }
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string FormaPagoDescripcion { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuario { get; set; }
        public int Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
    }

    public class CertificadoEstadoCuentaModel
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public string NombreCliente { get; set; }
        public int IdVendedor { get; set; }
        public decimal ValorPaquete { get; set; }
        public decimal PagoInicial { get; set; }
        public decimal TotalAbonado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal MontoMensualidad { get; set; }
        public int Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }
    }

    public class CertificadoAbonoReporteModel
    {
        public int IdAbono { get; set; }
        public int IdCertificado { get; set; }
        public int FolioCertificado { get; set; }
        public int FolioAbono { get; set; }
        public string FechaAbono { get; set; }
        public string NombreCliente { get; set; }
        public int IdVendedor { get; set; }
        public decimal ValorPaquete { get; set; }
        public decimal PagoInicial { get; set; }
        public decimal MontoAbono { get; set; }
        public int FormaPago { get; set; }
        public string FormaPagoDescripcion { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public int? IdUsuario { get; set; }
        public int TipoCertificado { get; set; }
        public string TipoCertificadoDescripcion { get; set; }
        public int EstatusAbono { get; set; }
        public string EstatusAbonoDescripcion { get; set; }
        public decimal TotalAbonadoCertificado { get; set; }
        public decimal RestanteCertificado { get; set; }
    }
}