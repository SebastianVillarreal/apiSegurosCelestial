namespace marcatel_api.Models
{
    public class ReporteAbonosRequest
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
    public class ReporteAbonosModel
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public string FechaAbono { get; set; }
        public string MetodoPago { get; set; }
        public string Referencia { get; set; }
    }
}

