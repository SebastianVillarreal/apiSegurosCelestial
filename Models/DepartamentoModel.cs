namespace marcatel_api.Models
{
    public class DepartamentoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
        public decimal compraTotal {get; set;}
        public decimal compraNeta {get; set;}
        public decimal ieps {get; set;}
        public decimal iva {get; set;}
        public decimal descuentos {get; set;}
        public decimal devoluciones {get; set;}

    }
}