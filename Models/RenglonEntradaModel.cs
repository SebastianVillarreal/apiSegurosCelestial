namespace marcatel_api.Models
{
    public class RenglonEntradaModel
    {
        public int Entrada { get; set; }
        public int Renglon { get; set; }
        public float Cantidad { get; set; }
        public float Costo { get; set; }
        public float CostoRenglon { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public float CostoOrden { get; set; }
        public int id {get; set;}
    }
}