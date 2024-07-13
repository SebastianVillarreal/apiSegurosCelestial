namespace marcatel_api.Models
{
    public class ArticuloOfertaModel
    {
        public int Id {get; set;}
        public int Oferta { get; set; }
        public int IdSucursal { get; set; }
        public string Articulo { get; set; }
        public float Descuento { get; set; }
        public decimal PrecioOferta {get; set;}
        public decimal PrecioOriginal {get; set;}
        public string Descripcion {get; set;}
    }
}