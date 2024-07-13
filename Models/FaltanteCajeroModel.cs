namespace marcatel_api.Models
{
    public class FaltanteCajeroModel
    {
        public int Id {get; set;}
        public int IdUsuario {get; set;}
        public int IdCorte {get; set;}
        public int IdSucursal {get;set ;}
        public string Sucursal {get; set;}
        public string Cajero {get; set;}
        public int Autoriza {get; set;}
        public decimal Monto {get; set;}
        public string Fecha {get; set;}
        public int Estatus {get; set;}
        public string Caja {get; set;}


    }
}