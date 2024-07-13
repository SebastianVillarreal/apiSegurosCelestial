namespace marcatel_api.Models
{
    public class DetalleFolioModel 
    {
        public int Id {get; set;}
        public int IdFolio {get; set;}
        public string FolioInterno {get; set;}
        public decimal Abono {get; set;}
        public decimal Restante {get; set;}
        public string Concepto {get; set;}
        public string Referencia {get; set;}
    }
}