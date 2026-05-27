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
}