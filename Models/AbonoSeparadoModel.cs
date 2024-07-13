namespace marcatel_api.Models
{
    public class AbonoSeparadoModel: AbonoModel
    {
        public int IdSeparado { get; set; }
        public decimal RestoSeparado {get; set;}
        public int IdUsuario {get; set;}
        public decimal Abonado {get; set;}
    }
}