namespace marcatel_api.Models
{
    public class RenglonOrdenCompraModel
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string Articulo { get; set; }
        public string UnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public float Importe { get; set; }
        public string ClaveIva { get; set; }
        public string Observaciones { get; set; }
        public int Renglon { get; set; }
        public int ReqRenglon { get; set; }
        public float Iva { get; set; }
        public int IepsSN { get; set; }
        public float Ieps { get; set; }
        public string ClaveIeps { get; set; }
        public int IdOrden { get; set; }
        public string clave {get; set;}
    }
}