using Newtonsoft.Json;

namespace marcatel_api.Models
{
    public class CartaFaltanteModel
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string TipoOrden { get; set; }
        public string ClaveProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string NumeroFactura { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public string FechaElaboracion { get; set; }
        [JsonIgnore]
        public string HoraElaboracion { get; set; }
        [JsonIgnore]
        public string FechaAfectacion { get; set; }
        public string HoraAfectacion { get; set; }
        [JsonIgnore]
        public float TotalDiferencia { get; set; }
        public int Bodeguero { get; set; }
        public string Transportista { get; set; }
        public string NombreBodeguero { get; set; }
        public string Status { get; set; }
        public string NotaEntrada {get; set;}

    }
}