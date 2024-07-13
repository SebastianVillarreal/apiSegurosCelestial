namespace marcatel_api.Models
{
    public class ListaPreciosModel
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public int IdProveedor { get; set; }
        public int Folio { get; set; }
        public string Usuario { get; set; }
    }

    public class PaginacionModel
    {
        public int skip { get;set;}
        public int pageSize { get; set; }
        public string search { get; set; }
    }
}

