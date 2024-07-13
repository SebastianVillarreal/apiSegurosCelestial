namespace marcatel_api.Models
{
    public class RenglonListaPreciosModel
    {
        public int Id { get; set; }
        public int IdLista { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public float CostoAD { get; set; }
        public float CostoDD { get; set; }
        public float D1 { get; set; }
        public float D2 { get; set; }
        public float D3 { get; set; }
        public float D4 { get; set; }
        public float D5 { get; set; }
    }
}