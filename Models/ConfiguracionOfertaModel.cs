namespace marcatel_api.Models
{
    public class ConfiguracionOfertaModel
    {
        public int Oferta { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public int Tipo { get; set; }
        public float Descuento { get; set; }
        public int[] Dias { get; set; }
        public int[] Sucursales { get; set; }
    }
}