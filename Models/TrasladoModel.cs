namespace marcatel_api.Models
{
    public class TrasladoModel
    {
        public int Id {get; set;}
        public int IdFactura {get; set;}
        public int IdTraslado {get; set;}
        public decimal Total {get; set;}
        public string Nombre {get; set;}
        public string Impuesto {get; set;}
        public string Tasa {get; set;}
        public string Base {get; set;}
        public string Factor {get; set;}
        public string TasaCuota {get; set;}
    }
}
