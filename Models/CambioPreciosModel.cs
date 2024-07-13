namespace marcatel_api.Models
{
    public class CambioPrecioModel
    {
        public string Codigo {get; set;}
        public decimal CostoActual {get; set;}
        public decimal NuevoCosto {get; set;}
        public string Fecha {get; set;}
    }
}