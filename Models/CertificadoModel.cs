using System;

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
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
    }

    public class UpdateCertificadoModel
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public int IdVendedor { get; set; }
        public string NombreCliente { get; set; }
        public decimal ValorPaquete { get; set; }
        public decimal PagoInicial { get; set; }
        public decimal MontoMensualidad { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int Estatus { get; set; }
    }

    public class CertificadoUpdateResponse
    {
        public string Mensaje { get; set; }
        public int IdCertificado { get; set; }
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
        public int AbonoVencido {get; set;}
        public string FechaUltimoAbono { get; set; }
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

    public class CertificadoAbonoDetalleModel
    {
        public int Id { get; set; }
        public int IdCertificado { get; set; }
        public int FolioCertificado { get; set; }
        public string NombreCliente { get; set; }
        public decimal ValorPaquete { get; set; }
        public decimal PagoInicial { get; set; }
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
        public decimal TotalAbonado { get; set; }
        public decimal RestanteCertificado { get; set; }
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

    public class CertificadoCarteraVencidaModel
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public string NombreCliente { get; set; }
        public string FechaRegistro { get; set; }
        public decimal PagoInicial { get; set; }
        public decimal MontoMensualidad { get; set; }
        public decimal TotalAbonos { get; set; }
        public decimal TotalPagado { get; set; }
        public string FechaUltimoAbono { get; set; }
        public int CantidadMovimientosAbono { get; set; }
        public int MensualidadesEsperadas { get; set; }
        public int MensualidadesCubiertas { get; set; }
        public decimal AbonoParcialMensualidad { get; set; }
        public decimal ImporteEsperado { get; set; }
        public decimal MontoVencido { get; set; }
        public int MensualidadesVencidas { get; set; }
        public string FechaPrimerVencimientoPendiente { get; set; }
        public int DiasVencidos { get; set; }
        public decimal PendienteMensualidadMasAntigua { get; set; }
    }

    public class InsertServicioFunerarioModel
    {
        public string ResponsableNombre { get; set; }
        public string ResponsableParentesco { get; set; }
        public string ResponsableTelefono { get; set; }
        public string ResponsableCorreo { get; set; }
        public string ResponsableDomicilio { get; set; }
        public string ResponsableColonia { get; set; }
        public string ResponsableCiudad { get; set; }
        public string ResponsableCP { get; set; }
        public string ResponsableTipoIdentificacion { get; set; }
        public string ResponsableOtraIdentificacion { get; set; }
        public string ResponsableNumeroIdentificacion { get; set; }

        public string FallecidoNombre { get; set; }
        public int? FallecidoEdad { get; set; }
        public DateTime? FallecidoFechaNacimiento { get; set; }
        public DateTime? FallecidoFechaDefuncion { get; set; }
        public string FallecidoLugarTipo { get; set; }
        public string FallecidoLugarOtro { get; set; }
        public string FallecidoHospitalLugar { get; set; }
        public string FallecidoCiudad { get; set; }

        public bool TrasladoLocal { get; set; }
        public bool TrasladoForaneo { get; set; }
        public bool PreparacionEstetica { get; set; }
        public bool Embalsamado { get; set; }
        public bool Ataud { get; set; }
        public bool SalaVelacion { get; set; }
        public bool Cremacion { get; set; }
        public bool Inhumacion { get; set; }
        public bool Carroza { get; set; }
        public bool GestionTramites { get; set; }
        public bool Cafeteria { get; set; }
        public bool ServicioOtro { get; set; }
        public string ServicioOtroDescripcion { get; set; }

        public string LugarTraslado { get; set; }
        public string DestinoFinal { get; set; }
        public DateTime? FechaServicio { get; set; }
        public TimeSpan? HoraServicio { get; set; }
        public string TipoServicio { get; set; }
        public string CapillaSala { get; set; }
        public string TiempoEstimado { get; set; }

        public decimal CostoTotal { get; set; }
        public decimal Anticipo { get; set; }
        public string FormaPago { get; set; }

        public string Observaciones { get; set; }
        public int? Usuario { get; set; }
        public string FechaFormato { get; set; }
    }

    public class ServicioFunerarioModel : InsertServicioFunerarioModel
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public string FechaRegistro { get; set; }
        public int? UsuarioRegistro { get; set; }
        public string FechaModificacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public int Estatus { get; set; }
        public string FechaFormato { get; set; }
    }
}