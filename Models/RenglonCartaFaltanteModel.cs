using Newtonsoft.Json;

namespace marcatel_api.Models
{
    public class RenglonCartaFaltanteModel
    {
        public int Id { get; set; }
        public int IdCarta { get; set; }
        public float CantidadProducto { get; set; }
        public float CostoUnitario { get; set; }
        public float TotalRenglon { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        [JsonIgnore]
        public string Fecha { get; set; }
        [JsonIgnore]
        public string Hora { get; set; }
    }
}