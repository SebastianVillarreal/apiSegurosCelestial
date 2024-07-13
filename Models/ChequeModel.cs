namespace marcatel_api.Models
{
    public class ChequeModel
    {
        public int Id {get; set;}
        public int IdProveedor {get; set;}
        public int IdSucursal {get; set;}
        public decimal Total {get; set;}
        public string Serie {get; set;}
        public string Proveedor {get; set;}
        public string Sucursal {get; set;}
        public string nombreUsuario {get; set;}
        public string NombreProveedor {get; set;}

    }

    public class RenglonChequeModel
    {
        public int Id {get; set;}
        public int IdCheque {get; set;}
        public int IdRemision {get; set;}
    }
}