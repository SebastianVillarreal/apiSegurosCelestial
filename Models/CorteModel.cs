namespace marcatel_api.Models
{
    public class CorteModel
    {
        public int Id { get; set; }
        public int IdSucursal { get; set; }
        public int Caja { get; set; }
        public int Cajero { get; set; }
        public string NombreCajero { get; set; }
        public string NombreSucursal { get; set; }
        public string Fecha { get; set; }
        public string Estatus { get; set; }
        public int IdReferencia { get; set; }
        public int IdSes { get; set; }
        public string FechaApertura { get; set; }
        public string FechaCierre { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstatus { get; set; }
        public decimal VentaTotal {get; set;}
        public int IdCorte {get; set;}
        public string FechaFormat {get; set;}
        public decimal DevolucionesPagadas {get; set;}
    }

    public class GetTotalCorte
    {
        public decimal Total {get; set;}
        public string Usuario {get; set;}
    }
}
